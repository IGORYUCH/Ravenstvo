using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workplace.Models
{
    public class Workplace_
    {
        public int Id { get; set; }
        [ForeignKey("ComputerId")]
        public Computer Computer { get; set; }
    }
}
