using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class BulkDictionaryEntry
    {
        [Required]
        public String Entry { get; set; }
    }
}
