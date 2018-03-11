using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

        public Style Style { get; set; }
        public bool HasWheels { get; set; }
        public virtual ICollection<TrainerCorrectResponse> CorrectResponses { get; set; }
    }
    public class TrainerCorrectResponse
    {
        public int TrainerCorrectResponseId { get; set; }
        [Display(Name = "Правильный ответ")]
        [Required]
        public string Answer { get; set; }
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
