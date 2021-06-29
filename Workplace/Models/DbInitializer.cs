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
                new GraphicsCard {Frequency=1800, Volume=2048},
                new GraphicsCard {Frequency=1866, Volume=2048},
                new GraphicsCard {Frequency=1600, Volume=1024},
                new GraphicsCard {Frequency=1850, Volume=4096},
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
                    new Processor{Cores=4, Threads=4, Frequency=3000},
                    new Processor{Cores=2, Threads=4, Frequency=2600},
                    new Processor{Cores=4, Threads=4, Frequency=3300},
                    new Processor{Cores=8, Threads=8, Frequency=4200},
                    new Processor{Cores=4, Threads=8, Frequency=3600},
                };
                context.AddRange(processors);

                List<SystemUnit> systemUnits = new List<SystemUnit>
                {
                    new SystemUnit {Disk=disks[3], Memory=memories[3], Motherboard=motherboards[4], Processor=processors[2]},
                    new SystemUnit {Disk=disks[1], Memory=memories[2], Motherboard=motherboards[4], Processor=processors[3]},
                    new SystemUnit {Disk=disks[2], Memory=memories[3], Motherboard=motherboards[4], Processor=processors[3]},
                    new SystemUnit {Disk=disks[0], Memory=memories[2], Motherboard=motherboards[1], Processor=processors[2]},
                    new SystemUnit {Disk=disks[1], Memory=memories[3], Motherboard=motherboards[2], Processor=processors[1]},
                    new SystemUnit {Disk=disks[2], Memory=memories[0], Motherboard=motherboards[3], Processor=processors[0]},
                };
                context.AddRange(systemUnits);


                List<Keyboard> keyboards = new List<Keyboard>
                {
                    new Keyboard {ConnectType="USB",HasNumpad=true, Keys=100},
                    new Keyboard {ConnectType="Bluethooth", HasNumpad=true, Keys=100},
                    new Keyboard {ConnectType="Wireless", HasNumpad=false, Keys=87},
                    new Keyboard {ConnectType="USB", HasNumpad=true, Keys=100},
                    new Keyboard {ConnectType="Bluethooth", HasNumpad=false, Keys=87},
                    new Keyboard {ConnectType="PS/2", HasNumpad=true, Keys=105},
                    new Keyboard {ConnectType="TESTER", HasNumpad=true, Keys=105},
                };
                context.AddRange(keyboards);

                List<Mouse> mice = new List<Mouse>
                {
                    new Mouse {ConnectType="USB"},
                    new Mouse {ConnectType="PS/2"},
                    new Mouse {ConnectType="PS/2"},
                    new Mouse {ConnectType="Wireless"},
                    new Mouse {ConnectType="USB"},
                    new Mouse {ConnectType="Bluethooth"},
                    new Mouse {ConnectType="TESTER"},
                };
                context.AddRange(mice);

                List<Monitor> monitors = new List<Monitor> //10
                {
                    new Monitor {Frequency=60, ResolutionX=1600, ResolutionY=900},
                    new Monitor {Frequency=75, ResolutionX=1366, ResolutionY=768},
                    new Monitor {Frequency=60, ResolutionX=1366, ResolutionY=768},
                    new Monitor {Frequency=75, ResolutionX=1366, ResolutionY=768},
                    new Monitor {Frequency=60, ResolutionX=1920, ResolutionY=1080},
                    new Monitor {Frequency=75, ResolutionX=1920, ResolutionY=1080},
                    new Monitor {Frequency=60, ResolutionX=1920, ResolutionY=1080},
                    new Monitor {Frequency=75, ResolutionX=1366, ResolutionY=768},
                    new Monitor {Frequency=75, ResolutionX=1920, ResolutionY=1080},
                    new Monitor {Frequency=75, ResolutionX=1366, ResolutionY=768},
                    new Monitor {Frequency=144, ResolutionX=1366, ResolutionY=768},
                    new Monitor {Frequency=144, ResolutionX=1366, ResolutionY=768},
                };
                context.AddRange(monitors);

                List<Computer> computers = new List<Computer>
                {
                    new Computer {SystemUnit=systemUnits[0], Keyboard=keyboards[0], Mouse=mice[0], Monitors={monitors[0], monitors[1] } },
                    new Computer {SystemUnit=systemUnits[1], Keyboard=keyboards[1], Mouse=mice[1], Monitors={monitors[2], monitors[3] } },
                    new Computer {SystemUnit=systemUnits[2], Keyboard=keyboards[2], Mouse=mice[2], Monitors={monitors[4] } },
                    new Computer {SystemUnit=systemUnits[3], Keyboard=keyboards[3], Mouse=mice[3], Monitors={monitors[5], monitors[6] }},
                    new Computer {SystemUnit=systemUnits[4], Keyboard=keyboards[4], Mouse=mice[4], Monitors={monitors[7], monitors[8] }},
                    new Computer {SystemUnit=systemUnits[5], Keyboard=keyboards[5], Mouse=mice[5], Monitors={monitors[9] }},
                };
                context.AddRange(computers);

                List<Workplace_> workplaces = new List<Workplace_>
                {
                    new Workplace_{Computer=computers[0]},
                    new Workplace_{Computer=computers[1]},
                    new Workplace_{Computer=computers[2]},
                    new Workplace_{Computer=computers[3]},
                    new Workplace_{Computer=computers[4]},
                    new Workplace_{Computer=computers[5]}
                };
                context.AddRange(workplaces);

                context.SaveChanges();
            }
        }
    }
}
