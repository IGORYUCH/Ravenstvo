using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplace.Models
{
    public class GraphicsCard
    {
        public int Id { get; set; }
        public int Frequency { get; set; }
        public int Volume { get; set; }
        public GraphicsCardArchitecture Architecture { get; set; }
    }
}
