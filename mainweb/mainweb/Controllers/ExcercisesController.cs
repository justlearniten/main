using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mainweb.Data;
using mainweb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace mainweb.Controllers
{
    public class ExcercisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ExcercisesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
     
        // GET: Excercises
        public async Task<IActionResult> Index()
        {
            ViewData["IsAdmin"] = false;
            var user = await _userManager.GetUserAsync(User);
            if (user!=null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                ViewData["IsAdmin"] = roles.Contains("Administrator");
            }
            return View(await _context.Excercise.ToListAsync());
        }
        // GET: Excercises/list
        [Authorize]
        public IActionResult List()
        {
            IList<String[]> res = new List<String[]>();
            foreach (var e in _context.Excercise.OrderByDescending(e=>e.ExcerciseId))
            {
                res.Add(new String[]
                {
                    e.ExcerciseName,
                    e.ExcerciseId.ToString()
                });
            }
            return Json(res.ToArray());
        }
        // GET: Excercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _context.Excercise
                .SingleOrDefaultAsync(m => m.ExcerciseId == id);
            if (excercise == null)
            {
                return NotFound();
            }
            var a = Request.Headers["Accept"];
            _context.Entry(excercise).Collection(e => e.ExcerciseItems).Load();
            if (a.Count > 0 && String.Compare(a[0], "application/json", true) == 0 && HttpContext.User.Identity.IsAuthenticated)
            {
                
                return Json(ExcerciseDetailsViewModel.FromExcercise(excercise));
            }
            return View(excercise);
        }
        [Authorize]
        public async Task<IActionResult> Check([FromBody] ExcerciseDetailsViewModel model)
        {
            Excercise excercise = await _context.Excercise
                .Include(e=>e.ExcerciseItems)
                .ThenInclude(ei=>ei.CorrectResponses)
                .SingleOrDefaultAsync(e => e.ExcerciseId == model.ExcerciseId);

            if (excercise == null)
                return NotFound();
            int points = excercise.Check(model);
            int maxPoints = excercise.ExcerciseItems.Count;

            Test test = new Test()
            {
                ExcerciseId = excercise.ExcerciseId,
                PointsEarned = points,
                PointsAvailable = maxPoints,
                TimeTaken = model.CurrentTime
            };
            var user = await _userManager.GetUserAsync(User);
            _context.Entry(user).Collection(e => e.TestsTaken).Load();
            var existingExcercise = user.TestsTaken.Where(tt => tt.ExcerciseId == excercise.ExcerciseId).FirstOrDefault();
            if(existingExcercise == null)
            {
                user.TestsTaken.Add(test);
            }
            else
            {
                existingExcercise.PointsAvailable = maxPoints;
                existingExcercise.PointsEarned = points;
                existingExcercise.TimeTaken = model.CurrentTime;
            }
            await _context.SaveChangesAsync();
            return Json(new { points = points, maxPoints = maxPoints});
        }
        public class CheckAnswerViewModel
        {
            public int QuestionId { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CheckAnswer([FromBody] CheckAnswerViewModel model)
        {
            var item = await _context.ExcerciseItem.FirstOrDefaultAsync(ei => ei.ExcerciseItemId == model.QuestionId);
            _context.Entry(item).Collection(i => i.CorrectResponses).Load();
            return Json(new { correct = item.Check(model.Answer)!=0 });
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        // GET: Excercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Excercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("ExcerciseId,ExcerciseName")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
               
                _context.Add(excercise);
                ExcerciseItem ei = new ExcerciseItem() { Question = "" };
                CorrectResponse cr = new CorrectResponse() { Answer = "" };
                ei.CorrectResponses = new CorrectResponse[] { cr };
                excercise.ExcerciseItems = new ExcerciseItem[] { ei };
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit",new { id = excercise.ExcerciseId });
            }
            return View(excercise);
        }

        // GET: Excercises/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _context.Excercise.SingleOrDefaultAsync(m => m.ExcerciseId == id);
            
                
            if (excercise == null)
            {
                return NotFound();
            }
            return View(new ExcerciseEditViewModel(excercise, _context));
        }

        // POST: Excercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] ExcerciseEditViewModel excerciseVM)
        {
            if (id != excerciseVM.ExcerciseId)
            {
                return NotFound();
            }
            Excercise excercise = excerciseVM.ToExcercise;
            if (ModelState.IsValid)
            {
                try
                {
                    // excercise.ExcerciseName = Utils.CleanUp(excercise.ExcerciseName);
                   
                    _context.Update(excercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcerciseExists(excercise.ExcerciseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(excerciseVM);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddExcerciseItem([FromBody] int excersizeId)
        {
            var excercise = await _context.Excercise
                //.Include(e => e.ExcerciseItems)
                //.ThenInclude(ei=>ei.CorrectResponses)
                .SingleOrDefaultAsync(m => m.ExcerciseId == excersizeId);
                
            if (excercise == null)
            {
                return NotFound();
            }
            ExcerciseItem newItem = new ExcerciseItem() { Question = "" };
            _context.Entry(excercise).Collection(e => e.ExcerciseItems).Load();
            excercise.ExcerciseItems.Add(newItem);

            await _context.SaveChangesAsync();
            newItem.CorrectResponses =new CorrectResponse[0];
            return Json(newItem);
        }
       
        public class AddAnswerModel {public int excerciseId; public int excerciseItemId; };
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddAnswer([FromBody] AddAnswerModel model)
        {
            Excercise e = await _context.Excercise.SingleOrDefaultAsync(ee => ee.ExcerciseId == model.excerciseId);
            if (e == null)
                return NotFound();
            _context.Entry(e).Collection(ee => ee.ExcerciseItems).Load();
            ExcerciseItem ei = e.ExcerciseItems.Where(ei2 => ei2.ExcerciseItemId == model.excerciseItemId).FirstOrDefault();
            if (ei == null)
                return NotFound();
            _context.Entry(ei).Collection(ei3 => ei3.CorrectResponses).Load();
            CorrectResponse cr = new CorrectResponse() { Answer = "" };
            ei.CorrectResponses.Add(cr);
            _context.SaveChanges();

            return Json(cr);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteItem([FromBody] AddAnswerModel model)
        {
            Excercise e = await _context.Excercise.SingleOrDefaultAsync(ee => ee.ExcerciseId == model.excerciseId);
            if (e == null)
                return NotFound();
            _context.Entry(e).Collection(ee => ee.ExcerciseItems).Load();
            ExcerciseItem ei = e.ExcerciseItems.Where(ei2 => ei2.ExcerciseItemId == model.excerciseItemId).FirstOrDefault();
            if (ei == null)
                return NotFound();
            e.ExcerciseItems.Remove(ei);
            
            _context.SaveChanges();

            return Ok();
        }
        public class DeleteAnswerModel { public int excerciseId; public int excerciseItemId; public int correctResponseId; };
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAnswer([FromBody] DeleteAnswerModel model)
        {
            Excercise e = await _context.Excercise
                .Include(ee2=>ee2.ExcerciseItems)
                .ThenInclude(d=>d.CorrectResponses)
                .SingleOrDefaultAsync(ee => ee.ExcerciseId == model.excerciseId);
            if (e == null)
                return NotFound();
            _context.Entry(e).Collection(ee => ee.ExcerciseItems).Load();
            ExcerciseItem ei = e.ExcerciseItems.Where(ei2 => ei2.ExcerciseItemId == model.excerciseItemId).FirstOrDefault();
            if (ei == null)
                return NotFound();
            //_context.Entry(ei).Collection(ei3 => ei3.CorrectResponses).Load();
            CorrectResponse cr2Delete = ei.CorrectResponses.Where(cr => cr.CorrectResponseId == model.correctResponseId).FirstOrDefault();
            if (cr2Delete == null)
                return NotFound();
            ei.CorrectResponses.Remove(cr2Delete);
            _context.SaveChanges();

            return Json(e.ExcerciseItems);
        }
        // GET: Excercises/Delete/5/
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _context.Excercise
                .SingleOrDefaultAsync(m => m.ExcerciseId == id);
            if (excercise == null)
            {
                return NotFound();
            }

            return View(excercise);
        }

        // POST: Excercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excercise = await _context.Excercise.SingleOrDefaultAsync(m => m.ExcerciseId == id);
            _context.Excercise.Remove(excercise);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ExcerciseExists(int id)
        {
            return _context.Excercise.Any(e => e.ExcerciseId == id);
        }
        [Authorize]
        public async Task<IActionResult> Progress()
        {
            var excercises = await _context.Excercise.ToListAsync();
            var user = await _userManager.GetUserAsync(User);
            _context.Entry(user).Collection(e => e.TestsTaken).Load();
            var res = new List<ProgressViewModel>();
            foreach(var ex in excercises)
            {
                ProgressViewModel pr = new ProgressViewModel() { Id = ex.ExcerciseId , ExcerciseName = ex.ExcerciseName};
                _context.Entry(ex).Collection(e => e.ExcerciseItems).Load();
                pr.PointsAvailable = ex.ExcerciseItems.Count;
                Test t = user.TestsTaken.FirstOrDefault(tt => tt.ExcerciseId == ex.ExcerciseId);
                if (t != null)
                {
                   
                    pr.PointsEarned = t.PointsEarned;
                    pr.TimeTaken = t.TimeTaken;
                }
                res.Add(pr);
            }
            
            return View(res);
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateGroup()
        {
            return View();
        }
    }
}
