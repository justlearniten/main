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
using HtmlAgilityPack;

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
            //get previous and next lesson Id
            var prevLesson = await _context.Lessons
                .Where(l => l.LessonGroupId == lesson.LessonGroupId && l.LessonId < lesson.LessonId)
                .OrderByDescending(l=>l.LessonId)
                .FirstOrDefaultAsync();
            if(prevLesson==null && lesson.LessonGroupId != null)
            {
                var prevGroup = await _context.LessonGroups
                    .Where(lg => lg.LessonGroupId < lesson.LessonGroupId)
                    .OrderByDescending(lg => lg.LessonGroupId)
                    .FirstOrDefaultAsync();
                int? prevGroupId = null;
                if (prevGroup != null)
                    prevGroupId = prevGroup.LessonGroupId;

                prevLesson = await _context.Lessons
                        .Where(l => l.LessonGroupId == prevGroupId)
                        .OrderByDescending(l=>l.LessonId)
                        .FirstOrDefaultAsync();
            }
            ViewData["PrevLessionId"] = prevLesson?.LessonId;
            ////////////////////////////////////////////////////////////
            var nextLesson = await _context.Lessons
                .Where(l => l.LessonGroupId == lesson.LessonGroupId && l.LessonId > lesson.LessonId)
                .OrderBy(l=>l.LessonId)
                .FirstOrDefaultAsync();
            if (nextLesson == null)
            {
                var nextGroup = await _context.LessonGroups
                    .Where(lg => lg.LessonGroupId > (lesson.LessonGroupId??0))
                    .OrderBy(lg => lg.LessonGroupId)
                    .FirstOrDefaultAsync();

                if (nextGroup != null)
                    nextLesson = await _context.Lessons
                        .Where(l => l.LessonGroupId == nextGroup.LessonGroupId)
                        .OrderBy(l => l.LessonId)
                        .FirstOrDefaultAsync();

            }
            ViewData["NextLessionId"] = nextLesson?.LessonId;

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
                    
                    var fullFilePath = FullNameForFile(lesson.FilePath);

                    System.IO.File.WriteAllText(fullFilePath, lessonEdit.Content);
                    SaveTrains(lesson, lessonEdit.Content);

                    _context.Update(lesson);
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

        private void SaveTrains(Lesson lesson, string content)
        {
            if(String.IsNullOrEmpty(lesson.TrainsPath))
                lesson.TrainsPath = CreateRandomFileName(".html");
            String fullPath = FullNameForFile(lesson.TrainsPath);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);
            var nodes = doc.DocumentNode.Descendants("table")
                .Where(x => x.Attributes["class"]?.Value == "train")
                .ToList();
            String res = "";
            foreach(var n in nodes)
            {
                res += n.OuterHtml +"<hr>";
            }
            System.IO.File.WriteAllText(fullPath, res);
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
