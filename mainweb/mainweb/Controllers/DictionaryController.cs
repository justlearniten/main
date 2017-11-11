using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mainweb.Data;
using mainweb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace mainweb.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DictionaryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            ViewData["IsAdmin"] = false;
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                ViewData["IsAdmin"] = roles.Contains("Administrator");
            }

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
        public async Task<IActionResult> Create()
        {
            await CheckAdmin();
            return View();
        }

        private async Task CheckAdmin()
        {
            ViewData["IsAdmin"] = false;
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                ViewData["IsAdmin"] = roles.Contains("Administrator");
            }
        }
        private async Task PopulateStats()
        {
            int countTotal = _context.Dictionary.Count();
            int countEng = _context.Dictionary.Count(d => d.DicDirection == DictionaryEntry.Direction.ENGRUS);
            int countTrans = _context.Translations.Count();

            ViewData["DictionaryTotal"] = countTotal;
            ViewData["DictionaryEng"] = countEng;
            ViewData["DictionaryTrans"] = countTrans;
        }
        // POST: Dictionary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Entry")]BulkDictionaryEntry model)
        {
            await CheckAdmin();
            if (model.Entry != null)
            {
                try
                {
                    foreach (string l in model.Entry.Split("\n\r".ToArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        Console.WriteLine(l);
                        await AddLineToDictionary(l);
                    }
                }
                catch (Exception e)
                {
                    ViewData["error"] = e.Message;
                    return View(model);
                }
            }
            return View();
        }
        public async Task AddLineToDictionary(String l)
        {
            String[] splitted = l.Split(":".ToArray(),StringSplitOptions.RemoveEmptyEntries);
            if (splitted.Length != 2)
                throw new Exception("Неверный формат строки: " + l);
            string word = NormalizeWord(splitted[0]);
            DictionaryEntry dictionary = await _context.Dictionary.FirstOrDefaultAsync(d => d.Text == word);
            if (dictionary == null)
            {
                DictionaryEntry.Direction dir = DictionaryEntry.Direction.ENGRUS;
                if (word[0] >= 'а' && word[0] <= 'я') dir = DictionaryEntry.Direction.RUSENG;
                dictionary = new DictionaryEntry() {
                    Text = word,
                    DicDirection = dir,
                    Translatins = new List<Translation>()
                };
                await _context.Dictionary.AddAsync(dictionary);
            }
            else
            {
                _context.Entry(dictionary).Collection(d => d.Translatins).Load();
            }
            foreach(string t in splitted[1].Split(";".ToArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                string translation = NormalizeTranslation(t);
                if (dictionary.Translatins.FirstOrDefault(tt=>tt.Text==translation)==null)
                    dictionary.Translatins.Add(new Translation() {Text = translation});
            }
            
            await _context.SaveChangesAsync();
        }

        private string NormalizeTranslation(string v)
        {
            string res = v.Trim();
            while (res.Contains("  "))
                res = res.Replace("  ", " ");
            return res;
        }

        private string NormalizeWord(string v)
        {
            String res = v.Trim();
            res = res.ToLower();
            while (res.Contains("  "))
                res = res.Replace("  ", " ");
            return res;
        }

        // GET: Dictionary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View(null);
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
