using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplace.DTOs
{
    public class IncomingComputer
    {
        public int Id { get; set; }
        public int SystemUnitId { get; set; }
        public int KeyboardId { get; set; }
        public int MouseId { get; set; }
        public List<int> MonitorIds { get; set; }
        public IncomingComputer()
        {
            MonitorIds = new List<int>();
        }
    }
}
