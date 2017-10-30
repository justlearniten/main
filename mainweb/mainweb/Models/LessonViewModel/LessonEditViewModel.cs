using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace mainweb.Models
{
    public class LessonEditViewModel
    {
        public LessonEditViewModel(Lesson lesson)
        {
            LessonId = lesson.LessonId;
            Title = lesson.Title;
            LessonGroupId = lesson.LessonGroup?.LessonGroupId;
        }
        public LessonEditViewModel() { }
        public int LessonId { get; set; }
        [Display(Name = "Заголовок")]
        public String Title { get; set; }
        [Display(Name = "Название файла")]
        public String Content { get; set; }
        public int? LessonGroupId { get; set; }
    }
}
