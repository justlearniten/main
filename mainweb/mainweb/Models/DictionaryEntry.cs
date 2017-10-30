using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class DictionaryEntry
    {
        public int Id { get; set; }
        public enum Direction { ENGRUS, RUSENG};
       
        public Direction DicDirection { get; set;}
        [Display(Name = "Слово")]
        [Required]
        public string Text { get; set; }

        public virtual ICollection<Translation> Translatins { get; set; }

    }
}
