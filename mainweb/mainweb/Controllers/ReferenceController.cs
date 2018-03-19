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
        public async Task<IActionResult> Index(int? id)
        {

            if (id == null)
            {
                var refs = await _context.Reference.ToListAsync();
                ViewData["refs"] = refs;
            }
            else
            {
                var r = await _context.Reference.FindAsync(id);
                ViewData["file_path"] = r.FilePath;
                ViewData["file_title"] = r.Title;
            }
            return View();
        }
        private string FullNameForFile(string fileName)
        {
            return Path.Combine(_env.WebRootPath, "lessons", fileName);
        }
    }
}