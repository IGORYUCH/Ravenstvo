using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplace.Models
{
    public class Keyboard
    {
        public int Id { get; set; }
        public int Keys { get; set; } //87 short 100 full 100+ multimedia
        public bool HasNumpad { get; set; }
        public string ConnectType { get; set; }
    }
}
