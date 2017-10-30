using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mainweb.Data;
using mainweb.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace mainweb.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        public LessonsController(ApplicationDbContext context, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }
        private string FullNameForFile(string fileName)
        {
            return Path.Combine(_env.WebRootPath, "lessons", fileName);
        }
        private string CreateRandomFileName(string extension)
        {
            string uniqueStr = "jl" + Guid.NewGuid().ToString("N").ToUpper();
            return uniqueStr + extension;
        }
        // GET: Lessons
        public async Task<IActionResult> Index(int? id)
        {
            ViewData["IsAdmin"] = false;
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                ViewData["IsAdmin"] = roles.Contains("Administrator");
            }
            LessonsViewModel model = new LessonsViewModel();
            if (id == null)//load all
            {
                model.UngrouppedLessons = await _context.Lessons.Where(l => l.LessonGroup == null).ToListAsync();
                model.Groups = await _context.LessonGroups.Include(lg => lg.Lessons).ToListAsync();
                return View(model);
            }
            var lesson = await _context.Lessons
               .SingleOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }
            model.Lesson = lesson;
            return View(model);
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .SingleOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Lessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,Title,FilePath")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                lesson.FilePath = CreateRandomFileName(".html");
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                string fullName = FullNameForFile(lesson.FilePath);

                using (var f = System.IO.File.Create(fullName)) { }

                return RedirectToAction("Edit", new { id = lesson.LessonId});
            }
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.Include(l=>l.LessonGroup).SingleOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }
            
            var lessonView = new LessonEditViewModel(lesson);
            var fullFilePath = FullNameForFile(lesson.FilePath);
            lessonView.Content = System.IO.File.ReadAllText(fullFilePath);

            
            var groups = await _context.LessonGroups.ToListAsync();
            
            ViewBag.LessonGroups = new SelectList(groups, "LessonGroupId", "Title", lesson.LessonGroup?.LessonGroupId.ToString());
            return View(lessonView);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,Title,Content,LessonGroupId")] LessonEditViewModel lessonEdit)
        {
            if (id != lessonEdit.LessonId)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.Include(l=>l.LessonGroup).SingleOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    lesson.Title = lessonEdit.Title; //Only title is editable 
                    var lessonGroup = await _context.LessonGroups.SingleOrDefaultAsync(l => l.LessonGroupId == lessonEdit.LessonGroupId);
                    //if (lessonGroup == null)
                    //    return NotFound();
                    lesson.LessonGroup = lessonGroup;
                    _context.Update(lesson);
                    var fullFilePath = FullNameForFile(lesson.FilePath);

                    System.IO.File.WriteAllText(fullFilePath, lessonEdit.Content);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.LessonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(lessonEdit);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .SingleOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lessons.SingleOrDefaultAsync(m => m.LessonId == id);
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.LessonId == id);
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        // GET: Lessons/CreateGroup
        public IActionResult CreateGroup()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGroup([Bind("Title")] LessonGroup group)
        {
            if (ModelState.IsValid)
            {
               
                _context.Add(group);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("GroupsList");
            }
            return View(group);
        }
        public async Task<IActionResult> GroupsList()
        {
            return View(await _context.LessonGroups.ToListAsync());
        }
        [Authorize(Roles = "Administrator")]
        // GET: Lessons/DeleteGroup/5
        public async Task<IActionResult> DeleteGroup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.LessonGroups
                .SingleOrDefaultAsync(m => m.LessonGroupId == id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Lessons/DeleteGroup/5
        [HttpPost, ActionName("DeleteGroup")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGroupConfirmed(int id)
        {
            var group = await _context.LessonGroups.Include(g=>g.Lessons).SingleOrDefaultAsync(m => m.LessonGroupId == id);
            if (group == null)
                return NotFound();
           
            group.Lessons = null;
            _context.LessonGroups.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction("GroupsList");
        }

        // GET: Lessons/EditGroup/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditGroup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.LessonGroups.SingleOrDefaultAsync(m => m.LessonGroupId == id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGroup(int id,  LessonGroup group)
        {
            if (id != group.LessonGroupId)
            {
                return NotFound();
            }

            var group1 = await _context.LessonGroups.SingleOrDefaultAsync(m => m.LessonGroupId == id);
            if (group1 == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    group1.Title = group.Title; //Only title is editable 
                    _context.Update(group1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
                return RedirectToAction("GroupsList");
            }
            return View(group);
        }
    }
}
