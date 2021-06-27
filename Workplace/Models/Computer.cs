using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workplace.Models
{
    public class Computer
    {
        public int Id { get; set; }
        [ForeignKey("SystemUnitId")]
        public SystemUnit SystemUnit { get; set; }
        public List<Monitor> Monitors { get; set; }
    }
}
