using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models.LessonViewModel
{
    public class LessonListViewModel
    {
        List<Lesson> _items = new List<Lesson>();
        public List<Lesson> Items => _items;
        public void AddItem(Lesson item)
        {
            _items.Add(item);
        }
    }
}
