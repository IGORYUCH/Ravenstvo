using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Workplace.Models
{
    public class Workplace_
    {
        public int Id { get; set; }
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
    }
}
