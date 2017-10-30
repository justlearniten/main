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
    public class DictionaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictionaryController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Dictionary
        public async Task<IActionResult> Index(char l='A', DictionaryEntry.Direction dir=DictionaryEntry.Direction.ENGRUS)
        {
            if (l > 'Z')
                dir = DictionaryEntry.Direction.RUSENG;
            ViewData["dir"] = dir;
            ViewData["l"] = l.ToString().ToUpper();
            List<DictionaryEntry> res = await _context.Dictionary
                                                    .Include(de => de.Translatins)
                                                    .Where(de2 => de2.DicDirection == dir && de2.Text.ToUpper().StartsWith(l.ToString().ToUpper()))
                                                    .OrderBy(de3 => de3.Text)
                                                .ToListAsync();

            return View(res);
        }

        // GET: Dictionary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryEntry = await _context.Dictionary
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dictionaryEntry == null)
            {
                return NotFound();
            }

            return View(dictionaryEntry);
        }

        // GET: Dictionary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dictionary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DicDirection,Text")] DictionaryEntry dictionaryEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictionaryEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dictionaryEntry);
        }

        // GET: Dictionary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryEntry = await _context.Dictionary.SingleOrDefaultAsync(m => m.Id == id);
            if (dictionaryEntry == null)
            {
                return NotFound();
            }
            return View(dictionaryEntry);
        }

        // POST: Dictionary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DicDirection,Text")] DictionaryEntry dictionaryEntry)
        {
            if (id != dictionaryEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictionaryEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictionaryEntryExists(dictionaryEntry.Id))
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
            return View(dictionaryEntry);
        }

        // GET: Dictionary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryEntry = await _context.Dictionary
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dictionaryEntry == null)
            {
                return NotFound();
            }

            return View(dictionaryEntry);
        }

        // POST: Dictionary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictionaryEntry = await _context.Dictionary.SingleOrDefaultAsync(m => m.Id == id);
            _context.Dictionary.Remove(dictionaryEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DictionaryEntryExists(int id)
        {
            return _context.Dictionary.Any(e => e.Id == id);
        }
    }
}
