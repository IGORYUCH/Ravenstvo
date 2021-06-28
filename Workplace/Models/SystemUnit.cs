using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Workplace.Models
{
    public class SystemUnit
    {
        public int Id { get; set; }
        public int MotherboardId { get; set; }
        public Motherboard Motherboard { get; set; }
        public int ProcessorId { get; set; }
        public Processor Processor { get; set; }
        public int DiskId { get; set; }
        public Disk Disk { get; set; }
        public int MemoryId { get; set; }
        public Memory Memory { get; set; }
    }
}
