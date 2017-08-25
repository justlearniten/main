using mainweb.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class ExcerciseItemEditViewModel
    {
        public int ExcerciseItemId { get; set; }
        [Display(Name = "Вопрос")]
        [Required]
        public string Question { get; set; }
        public CorrectResponse[] CorrectResponses { get; set; }
        public ExcerciseItemEditViewModel() { }
        public ExcerciseItemEditViewModel(ExcerciseItem item, ApplicationDbContext context)
        {
            context?.Entry(item).Collection(i => i.CorrectResponses).Load();
            CorrectResponses = item.CorrectResponses.ToArray();
            ExcerciseItemId = item.ExcerciseItemId;
            Question = item.Question;
        }
        [JsonIgnore]
        public ExcerciseItem ToExcerciseItem
        {
            get
            {
                ExcerciseItem ei = new ExcerciseItem()
                {
                    ExcerciseItemId = this.ExcerciseItemId,
                    Question = this.Question,
                    CorrectResponses = this.CorrectResponses
                };
                return ei;
            }
        }
    }
    public class ExcerciseEditViewModel
    {

        public int ExcerciseId { get; set; }
        [Display(Name = "Название")]
        [Required]
        public string ExcerciseName { get; set; }
        public ExcerciseItemEditViewModel[] ExcerciseItems { get; set; }
        public ExcerciseEditViewModel() { }
        public ExcerciseEditViewModel(Excercise ex, ApplicationDbContext context)
        {
            context?.Entry(ex).Collection(e => e.ExcerciseItems).Load();
            ExcerciseItems = ex.ExcerciseItems.Select(i => new ExcerciseItemEditViewModel(i, context)).ToArray();

            ExcerciseId = ex.ExcerciseId;
            ExcerciseName = ex.ExcerciseName;
        }
        [JsonIgnore]
        public Excercise ToExcercise{
            get {
                Excercise ex = new Excercise()
                {
                    ExcerciseId = this.ExcerciseId,
                    ExcerciseName = this.ExcerciseName,
                    ExcerciseItems = this.ExcerciseItems.Select(i => i.ToExcerciseItem).ToList()
                };
                return ex;
            }
        }
    }
}
