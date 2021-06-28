using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Workplace.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public int SystemUnitId { get; set; }
        public SystemUnit SystemUnit { get; set; }
        public int KeyboardId { get; set; }
        public Keyboard Keyboard { get; set; }
        public int MouseId { get; set; }
        public Mouse Mouse { get; set; }
        public List<ComputerMonitor> ComputerMonitors { get; set; }
        public Computer()
        {
            ComputerMonitors = new List<ComputerMonitor>();
        }
    }
}
