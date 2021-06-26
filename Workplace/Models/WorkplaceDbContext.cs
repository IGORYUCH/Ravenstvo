using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Workplace.Models
{
    public class WorkplaceDbContext: DbContext
    {
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<SystemUnit> SystemUnits { get; set; }
        public WorkplaceDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WorkplaceDb;Trusted_Connection=True;");
        }
    }
}
