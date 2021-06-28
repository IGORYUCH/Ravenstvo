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
        [ForeignKey("SystemUnitId")]
        public SystemUnit SystemUnit { get; set; }
        [ForeignKey("KeyboardId")]
        public Keyboard Keyboard { get; set; }
        [ForeignKey("MouseId")]
        public Mouse Mouse { get; set; }
        public List<Monitor> Monitors { get; set; }
    }
}
