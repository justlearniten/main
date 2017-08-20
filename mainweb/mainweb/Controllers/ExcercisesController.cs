using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mainweb.Data;
using mainweb.Models;

namespace mainweb.Controllers
{
    public class ExcercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExcercisesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Excercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Excercise.ToListAsync());
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

            return View(excercise);
        }

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
        public async Task<IActionResult> Create([Bind("ExcerciseId,ExcerciseName")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
               
                _context.Add(excercise);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(excercise);
        }

        // GET: Excercises/Edit/5
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
            return View(excercise);
        }

        // POST: Excercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExcerciseId,ExcerciseName")] Excercise excercise)
        {
            if (id != excercise.ExcerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    excercise.ExcerciseName = Utils.CleanUp(excercise.ExcerciseName);
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
                return RedirectToAction("Index");
            }
            return View(excercise);
        }

        // GET: Excercises/Delete/5
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
    }
}
