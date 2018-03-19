using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class Reference
    {
        public int ReferenceId { get; set; }
        [Display(Name = "Заголовок")]
        [Required]
        public String Title { get; set; }
        [Display(Name = "Название файла")]
        public String FilePath { get; set; }
    }
}
