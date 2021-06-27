using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workplace.Models
{
    public class Monitor
    {
        public int Id { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public int Frequency { get; set; }
        [ForeignKey("SystemUnitId")]
        public SystemUnit SystemUnit { get; set; }
    }
}
