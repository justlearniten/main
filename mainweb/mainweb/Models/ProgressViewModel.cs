using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class ProgressViewModel
    {
        public int Id { get; set; }
        public string ExcerciseName { get; set; }
        public int PointsEarned { get; set; }
        public int PointsAvailable { get; set; }
        public DateTime TimeTaken { get; set; }
    }
}
