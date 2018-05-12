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
using HtmlAgilityPack;

namespace mainweb.Controllers
{
    [Authorize]
    public class TrainersController : Controller
    {
        const int NEW_ID = 2000000000;

        private readonly ApplicationDbContext _context;

        public TrainersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trainer.OrderByDescending(t=>t.TrainerId).ToListAsync());
        }

        // GET: Trainers/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer
                .SingleOrDefaultAsync(m => m.TrainerId == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // GET: Trainers/Create
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create()
        {
            var trainer = new Trainer() {
                Original="",
                Cars=new TrainerCar[]{
                    new TrainerCar()
                    {
                        CorrectResponses=new TrainerCorrectResponse[]
                        {
                            new TrainerCorrectResponse()
                            {
                                Answer=""
                            }
                        }
                    }
                }
            };
            _context.Trainer.Add(trainer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = trainer.TrainerId });
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new { id=trainer.TrainerId });
            }
            return View(trainer);
        }

        // GET: Trainers/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer.SingleOrDefaultAsync(m => m.TrainerId == id);
            if (trainer == null)
            {
                return NotFound();
            }
            await _context.Entry(trainer).Collection(t => t.Cars).LoadAsync();
            foreach (var tc in trainer.Cars)
                await _context.Entry(tc).Collection(c => c.CorrectResponses).LoadAsync();

            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody]  Trainer trainer)
        {
            if (id != trainer.TrainerId)
            {
                return NotFound();
            }

            var dbTrainer = await _context.Trainer.FindAsync(id);
            if (dbTrainer == null)
                return NotFound();
            _context.Entry(dbTrainer).Collection(t => t.Cars).Load();

            //change trainer properties
            dbTrainer.Original = trainer.Original;
            //remove deleted cars
            List<TrainerCar> cars2remove = new List<TrainerCar>();
            foreach(var c in dbTrainer.Cars)
            {
                var updatedCar = trainer.Cars.Where(cc => cc.TrainerCarId == c.TrainerCarId).FirstOrDefault();
                if (updatedCar == null)
                    cars2remove.Add(c);
                else
                {
                    c.HasWheels = updatedCar.HasWheels;
                    c.Style = updatedCar.Style;
                    List<TrainerCorrectResponse> responses2remove = new List<TrainerCorrectResponse>();
                    _context.Entry(c).Collection(car => car.CorrectResponses).Load();
                    foreach(var cr in c.CorrectResponses)
                    {
                        var updatedResponse = updatedCar.CorrectResponses.Where(ucr => ucr.TrainerCorrectResponseId == cr.TrainerCorrectResponseId).FirstOrDefault();
                        if (updatedResponse == null)
                            responses2remove.Add(cr);
                        else
                        {
                            cr.Answer = updatedResponse.Answer;
                        }
                    }
                    foreach (var r in responses2remove)
                        c.CorrectResponses.Remove(r);
                    //adding new correct responses
                    var newResponses = updatedCar.CorrectResponses.Where(ucr => ucr.TrainerCorrectResponseId >= NEW_ID);
                    foreach (var nr in newResponses)
                    {
                        nr.TrainerCorrectResponseId = 0;
                        c.CorrectResponses.Add(nr);
                    }
                        
                    
                }
            }
            foreach (var car in cars2remove)
                dbTrainer.Cars.Remove(car);
            var newCars = trainer.Cars.Where(c => c.TrainerCarId >= NEW_ID);
            foreach(var nc in newCars)
            {
                nc.TrainerCarId = 0;
                foreach (var r in nc.CorrectResponses)
                    r.TrainerCorrectResponseId = 0;
                dbTrainer.Cars.Add(nc);
            }
            await _context.SaveChangesAsync();
            return Json(dbTrainer);

        }
        [Authorize(Roles = "Administrator")]
        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer
                .SingleOrDefaultAsync(m => m.TrainerId == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainer = await _context.Trainer.SingleOrDefaultAsync(m => m.TrainerId == id);
            if (trainer == null)
                return NotFound();
            await _context.Entry(trainer).Collection(t => t.Cars).LoadAsync();
            foreach(var c in trainer.Cars)
            {
                await _context.Entry(c).Collection(cc => cc.CorrectResponses).LoadAsync();
                foreach (var cr in c.CorrectResponses)
                    _context.Remove(cr);
                _context.Remove(c);
            }
            _context.Trainer.Remove(trainer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrainerExists(int id)
        {
            return _context.Trainer.Any(e => e.TrainerId == id);
        }

        [Authorize]
        public IActionResult List()
        {
            IList<String[]> res = new List<String[]>();
            foreach (var t in _context.Trainer.OrderByDescending(t => t.TrainerId))
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(t.Original);
                
                var node = doc.DocumentNode;
                String title = node.InnerText;
                res.Add(new String[]
                {
                    title,
                    t.TrainerId.ToString()
                });
            }
            return Json(res.ToArray());
        }

        // GET: Excercises/Details/5
        public async Task<IActionResult> code(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer
                .SingleOrDefaultAsync(m => m.TrainerId == id);
            if (trainer == null)
            {
                return NotFound();
            }
            await _context.Entry(trainer).Collection(t => t.Cars).LoadAsync();
            int carCount = trainer.Cars.Count;
            String res = "<div class=\"trainer\">";
           
            res += "<table>";
            res += "<tr><td colspan="+ (2*carCount-1) +">"+trainer.Original+"</td></tr>";
            var row1 = "<tr>";
            var row2 = "<tr>";

            for (int i = 0; i < carCount; i++)
            {
                var car = trainer.Cars.ElementAt(i);
                var answers = "";
                await _context.Entry(car).Collection(c => c.CorrectResponses).LoadAsync();
                foreach (var cr in car.CorrectResponses) {
                    var an = cr.Answer.Trim().Replace("\\s+", " ").ToLower(); ;
                    answers += an + "%$";
                }
                row1 += "<td class=\"trainer-car correct\" answers=\"" +answers +"\"  >";
                var styleClass = car.Style.ToString().ToLower();
                row1 += "<div class=\"trainer-input-wrapper-" + styleClass + "\">";
                row1 += "<input class=\"trainer-input-" + styleClass + "\" oninput=\"trainerChange(this);\" />";
                row1 += "</div";

                row1 += "</td>";
                if (car.HasWheels)
                    row2 += "<td class=\"wheels\"></td>";
                else
                    row2 += "<td></td>";
                if (i != carCount - 1)
                {
                    row1 += "<td class=\"trainer-arrow\"></td>";
                    row2 += "<td></td>";
                }

            }

            row1 += "</tr>";
            row2 += "</tr>";
            res += row1;
            res += row2;
            res += "</table>";
            res += "<div>";
            return Ok(res);
                
           
        }
    }
}
