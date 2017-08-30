using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class ExcerciseItemDetailsViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public static ExcerciseItemDetailsViewModel FromExcerciseItem(ExcerciseItem item)
        {
            ExcerciseItemDetailsViewModel res = new ExcerciseItemDetailsViewModel()
            {
                QuestionId = item.ExcerciseItemId,
                Question = item.Question,
                Answer = ""
            };
            return res;
        }
    }
    public class ExcerciseDetailsViewModel
    {
        public int ExcerciseId { get; set; }
        public string ExcerciseName { get; set; }
        public ExcerciseItemDetailsViewModel[] ExcerciseItems { get; set; }
        public static ExcerciseDetailsViewModel FromExcercise(Excercise item)
        {
            ExcerciseDetailsViewModel res = new ExcerciseDetailsViewModel()
            {
                ExcerciseId = item.ExcerciseId,
                ExcerciseName = item.ExcerciseName,
                ExcerciseItems = item.ExcerciseItems.Select(ei => ExcerciseItemDetailsViewModel.FromExcerciseItem(ei)).ToArray()
            };
            return res;
        }
    }
}
