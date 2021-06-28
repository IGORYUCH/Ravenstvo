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
        public DbSet<Mouse> Mice { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Workplace_> Workplaces { get; set; }
        public WorkplaceDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputerMonitor>()
                .HasKey(t => new { t.ComputerId, t.MonitorId });

            modelBuilder.Entity<ComputerMonitor>()
                .HasOne(cm => cm.Computer)
                .WithMany(c => c.ComputerMonitors)
                .HasForeignKey(cm => cm.ComputerId);
                
            modelBuilder.Entity<ComputerMonitor>()
                .HasOne(cm => cm.Monitor)
                .WithMany(m => m.ComputerMonitors)
                .HasForeignKey(cm => cm.MonitorId);
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
