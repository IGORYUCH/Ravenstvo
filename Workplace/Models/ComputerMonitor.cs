using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workplace.Models
{
    public class ComputerMonitor
    {
        [Key]
        public int Id { get; set; }
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
        public int MonitorId { get; set; }
        public Monitor Monitor { get; set; }
    }
}
