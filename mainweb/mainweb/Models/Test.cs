using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Models
{
    public class Test
    {
        public int Id { get; set; }
        public DateTime TimeTaken { get; set; }
        public int ExcerciseId { get; set; }
        public int PointsEarned { get; set; }
        public int PointsAvailable { get; set; }
    }
}
