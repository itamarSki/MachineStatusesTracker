using System.Collections.ObjectModel;
using System.IO;

namespace MachineStatusesTracker.Models
{
    public class MachineManager
    {
        public static ObservableCollection<Machine> _MachinesDatabase = new ObservableCollection<Machine>() {
            new Machine { Name = "Equipment", Status = Status.ON, LogoSrc="/Views/Logos/ON.png", Notes="note1" },
            new Machine { Name = "Instrument", Status = Status.MAINTENANCE, LogoSrc="/Views/Logos/MAINTENANCE.png", Notes="note2" },
            new Machine { Name = "Piperun", Status = Status.OFF, LogoSrc = "/Views/Logos/OFF.png", Notes="note3" }
        };

        public static ObservableCollection<Machine> GetMachines()
        {
            return _MachinesDatabase;
        }

        public static void AddMachine(Machine machine)
        {
            _MachinesDatabase.Add(machine);
        }

        public static void DeleteMachine(Machine machine)
        {
            _MachinesDatabase.Remove(machine);
        }

        public static void ChangeMachineStatus(Machine machine, string selectedStatus)
        {
            machine.LogoSrc = ChangeFilename(machine.LogoSrc, $"{selectedStatus.ToString().ToUpper()}");
        }

        public static string ChangeFilename(string filepath, string newFilename)
        {
            string dir = Path.GetDirectoryName(filepath);
            string ext = Path.GetExtension(filepath);    
            return Path.Combine(dir, newFilename + ext).Replace('\\', '/');
        }
    }
}
