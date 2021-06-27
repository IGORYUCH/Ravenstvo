using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workplace.Models;

namespace Workplace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemUnitsController: ControllerBase
    {
        WorkplaceDbContext context;

        public SystemUnitsController()
        {
            context = new WorkplaceDbContext();
        }

        [HttpGet]
        public IEnumerable<SystemUnit> GetSystemUnits()
        {
            WorkplaceDbContext context = new WorkplaceDbContext();
            return context.SystemUnits.Include("Motherboard")
                .Include("Disk")
                .Include("Memory")
                .Include("Processor")
                ;
        }

        [HttpGet("{id}")]
        public ActionResult<SystemUnit> GetSystemUnit(int id)
        {
            SystemUnit systemUnit = context.SystemUnits.Find(id);
            if (systemUnit != null)
            {
                return systemUnit;
            }
            else
            {
                return NotFound(String.Format("The system unit with id {0} not found", id));
            }
        }
    }
}
