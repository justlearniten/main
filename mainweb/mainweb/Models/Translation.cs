using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class Translation
    {
        public int Id { get; set; }
        [Display(Name = "Перевод")]
        [Required]
        public string Text { get; set; }
    }
}
