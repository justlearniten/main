using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{

    public class Lesson
    {
        public int LessonId { get; set; }
        [Display(Name = "Заголовок")]
        [Required]
        public String Title { get; set; }
        [Display(Name = "Название файла")]
        public String FilePath { get; set; }
        public String TrainsPath { get; set; }
        [Display(Name ="Группа")]
        public virtual LessonGroup LessonGroup { get; set; }
        public int? LessonGroupId { get; set; }
        public bool AdminOnly { get; set; }
    }
    public class LessonGroup
    {
        public int LessonGroupId { get; set; }
        [Display(Name = "Название группы")]
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
    
}
