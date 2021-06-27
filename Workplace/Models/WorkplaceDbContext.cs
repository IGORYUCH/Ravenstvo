using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

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
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public WorkplaceDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
