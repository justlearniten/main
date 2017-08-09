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

namespace mainweb.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        public LessonsController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        private string FullNameForFile(string fileName)
        {
            return Path.Combine(_env.WebRootPath, "lessons", fileName);
        }
        private string CreateRandomFileName(string extension)
        {
            string uniqueStr = Guid.NewGuid().ToString("N").ToUpper();
            return uniqueStr + extension;
        }
        // GET: Lessons
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return View(await _context.Lessons.ToListAsync());
            }
            var lesson = await _context.Lessons
               .SingleOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(new Lesson[] { lesson });
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
        [Authorize]
        // GET: Lessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.SingleOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }
            var lessonView = new LessonEditViewModel(lesson);
            var fullFilePath = FullNameForFile(lesson.FilePath);
            lessonView.Content = System.IO.File.ReadAllText(fullFilePath);

            return View(lessonView);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,Title,Content")] LessonEditViewModel lessonEdit)
        {
            if (id != lessonEdit.LessonId)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.SingleOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    lesson.Title = lessonEdit.Title; //Only title is editable 
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
        [Authorize]
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
        [Authorize]
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
    }
}
