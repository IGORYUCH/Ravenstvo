using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Workplace.Models
{
    public class Monitor
    {
        public int Id { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public int Frequency { get; set; }
        public int MyProperty { get; set; }
        public List<ComputerMonitor> ComputerMonitors { get; set; }
        public Monitor()
        {
            ComputerMonitors = new List<ComputerMonitor>();
        }
    }
}
