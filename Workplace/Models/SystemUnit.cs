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
        [ForeignKey("MotherboardId")]
        public Motherboard Motherboard { get; set; }
        [ForeignKey("ProcessorId")]
        public Processor Processor { get; set; }
        [ForeignKey("DiskId")]
        public Disk Disk { get; set; }
        [ForeignKey("MemoryId")]
        public Memory Memory { get; set; }
    }
}
