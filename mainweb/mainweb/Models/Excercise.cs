using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class CorrectResponse
    {
        public int CorrectResponseId { get; set; }
        [Display(Name = "Правильный ответ")]
        [Required]
        public string Answer { get; set; }
    }
    public class ExcerciseItem
    {
        public int ExcerciseItemId { get; set; }
        [Display(Name ="Вопрос")]
        [Required]
        public string Question { get; set; }
        public virtual ICollection<CorrectResponse> CorrectResponses { get; set; }
        public ExcerciseItem()
        {
          
        }
    }
    public class Excercise
    {
        public int ExcerciseId { get; set; }
        [Display(Name ="Название")]
        [Required]
        public string ExcerciseName { get; set; }
        public virtual ICollection<ExcerciseItem> ExcerciseItems { get; set; }
        
        public int Points {
            get {
                return 0;//TODO:
            }
        }
    }
}
