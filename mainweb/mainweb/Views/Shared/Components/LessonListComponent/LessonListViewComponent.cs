using mainweb.Data;
using mainweb.Models.LessonViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Views.Shared.Components
{
    [ViewComponent(Name = "LessonListComponent")]
    public class LessonListViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public LessonListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(object parameter)
        {
            var model = new LessonListViewModel();
            foreach(var l in _context.Lessons)
            {
                model.AddItem(l);
            }
            return View(model);
        }
    }
}
