using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplace.Models
{
    public class Processor
    {
        public int Id { get; set; }
        public int Frequency { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
    }
}
