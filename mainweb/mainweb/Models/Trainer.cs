using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        [Display(Name = "Задание")]
        [Required]
        public String Original { get; set; }
        public virtual ICollection<TrainerCar> Cars { get; set; }
    }

    public class TrainerCar
    {
        public int TrainerCarId { get; set; }
        [Display(Name = "Стиль")]
        [Required]
        Style Style { get; set; }
        public bool HasWhheels { get; set; }
        public virtual ICollection<CorrectResponse> CorrectResponses { get; set; }
    }
   
    public enum Style
    {
        Normal,
        BlackSingle,
        RedSingle,
        BlackDouble,
        RedDouble
    }
}
