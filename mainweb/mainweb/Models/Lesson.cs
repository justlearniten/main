using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{

    public class Lesson
    {
        public int LessonId { get; set; }
        public String Title { get; set; }
        public String FilePath { get; set; }
    }
    
}
