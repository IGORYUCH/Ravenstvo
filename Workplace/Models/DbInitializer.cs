using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplace.Models
{
    public class DbInitializer
    {
        WorkplaceDbContext context;
        public DbInitializer(WorkplaceDbContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            context.Database.EnsureDeleted();
            if (context.Database.EnsureCreated())
            {
                List<GraphicsCard> cards = new List<GraphicsCard>
                {
                new GraphicsCard {Frequency=1800, Volume=2048, Architecture=GraphicsCardArchitecture.Pascal},
                new GraphicsCard {Frequency=1866, Volume=2048, Architecture=GraphicsCardArchitecture.RDNA2},
                new GraphicsCard {Frequency=1600, Volume=1024, Architecture=GraphicsCardArchitecture.Maxwell1},
                new GraphicsCard {Frequency=1850, Volume=4096, Architecture=GraphicsCardArchitecture.Pascal},
                };
                context.AddRange(cards);

                List<Disk> disks = new List<Disk>
                {
                    new Disk {RPM=5400, Volume=2048},
                    new Disk {RPM=7200, Volume=1024},
                    new Disk {RPM=7200, Volume=1024},
                    new Disk {RPM=5400, Volume=512},
                    new Disk {RPM=7200, Volume=512},
                };
                context.AddRange(disks);

                List<Motherboard> motherboards = new List<Motherboard>
                {
                    new Motherboard{ },
                    new Motherboard{ },
                    new Motherboard{ },
                    new Motherboard{ },
                    new Motherboard{ },
                };
                context.AddRange(motherboards);

                List<Memory> memories = new List<Memory>
                {
                    new Memory {Frequency=2666, Volume=16},
                    new Memory {Frequency=1333, Volume=32},
                    new Memory {Frequency=3200, Volume=8},
                    new Memory {Frequency=3200, Volume=32},
                    new Memory {Frequency=2800, Volume=8},
                    new Memory {Frequency=1866, Volume=8},
                };
                context.AddRange(memories);

                List<Processor> processors = new List<Processor>
                {
                    new Processor{Cores=4, Threads=4, Frequency=3000, Architecture=ProcessorArchitecture.CoffeeLake},
                    new Processor{Cores=2, Threads=4, Frequency=2600, Architecture=ProcessorArchitecture.Haswell},
                    new Processor{Cores=4, Threads=4, Frequency=3300, Architecture=ProcessorArchitecture.SandyLake},
                    new Processor{Cores=8, Threads=8, Frequency=4200, Architecture=ProcessorArchitecture.SkyLake},
                    new Processor{Cores=4, Threads=8, Frequency=3600, Architecture=ProcessorArchitecture.SkyLake},
                };
                context.AddRange(processors);

                List<SystemUnit> systemUnits = new List<SystemUnit>
                {
                    new SystemUnit {Disk=null, Memory=memories[3], Motherboard=motherboards[4], Processor=processors[2]},
                    new SystemUnit {Disk=disks[1], Memory=memories[2], Motherboard=motherboards[4], Processor=processors[3]},
                    new SystemUnit {Disk=disks[2], Memory=memories[3], Motherboard=motherboards[4], Processor=processors[3]},
                    new SystemUnit {Disk=disks[0], Memory=memories[2], Motherboard=motherboards[1], Processor=processors[2]},
                    new SystemUnit {Disk=disks[1], Memory=memories[3], Motherboard=motherboards[2], Processor=processors[1]},
                    new SystemUnit {Disk=disks[2], Memory=memories[0], Motherboard=motherboards[3], Processor=processors[0]},
                };
                context.AddRange(systemUnits);

                context.SaveChanges();
            }
        }
    }
}
