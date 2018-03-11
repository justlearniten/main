using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mainweb.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace mainweb.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        public ReferenceController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {

            
            String content = "";
            var UngrouppedLessons = await _context.Lessons.Where(l => l.LessonGroup == null).ToListAsync();
            var LessonGroups = await _context.LessonGroups.Include(lg => lg.Lessons).ToListAsync();
            foreach(var l in UngrouppedLessons)
            {
                if (String.IsNullOrEmpty(l.TrainsPath))
                    continue;
                string filePath = FullNameForFile(l.TrainsPath);
                String c = System.IO.File.ReadAllText(filePath);
                content +=  c ;
            }
            foreach (var g in LessonGroups)
            {
                foreach (var l in g.Lessons)
                {
                    if (String.IsNullOrEmpty(l.TrainsPath))
                        continue;
                    string filePath = FullNameForFile(l.TrainsPath);
                    String c = System.IO.File.ReadAllText(filePath);
                    content +=  c ;
                }
            }
            ViewData["content"] = content;
            return View();
        }
        private string FullNameForFile(string fileName)
        {
            return Path.Combine(_env.WebRootPath, "lessons", fileName);
        }
    }
}