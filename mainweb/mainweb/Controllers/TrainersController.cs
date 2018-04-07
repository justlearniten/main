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

namespace mainweb.Controllers
{
    [Authorize(Roles = "Administrator")]
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
            return View(await _context.Trainer.ToListAsync());
        }

        // GET: Trainers/Details/5
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

            return NotFound();
        }

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
    }
}
