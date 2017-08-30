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

        internal int Check(ExcerciseItemDetailsViewModel eid)
        {
            foreach (var cr in CorrectResponses)
                if (KindaEqual(cr.Answer, eid.Answer))
                    return 1;
            return 0;
        }

        internal bool KindaEqual(string one, string two)
        {
            return NormalizeStr(one) == NormalizeStr(two); ;

        }

        private string NormalizeStr(string str)
        {
            string res = str.Trim();
            res = res
                .Replace(".", " . ")
                .Replace("!", " ! ")
                .Replace("?", " ? ")
                .Replace("'", " ' ");
            while (res.Contains("  "))
                res = res.Replace("  ", " ");
            res = res.ToUpper();
            return res;
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

        internal int Check(ExcerciseDetailsViewModel model)
        {
            int res = 0;
            for(var i=0;i<model.ExcerciseItems.Length;i++)
            {
                ExcerciseItem ei = ExcerciseItems.ElementAt(i);
                ExcerciseItemDetailsViewModel eid = model.ExcerciseItems[i];
                res += ei.Check(eid);
            }
            return res;
        }
    }
}
