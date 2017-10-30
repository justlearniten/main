using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class LessonsViewModel
    {
        public IEnumerable<Lesson> UngrouppedLessons { get; set; }
        public IEnumerable<LessonGroup> Groups { get; set; }
        public Lesson Lesson { get; set; }//only one to display
    }
}
