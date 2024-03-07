using System.Windows.Input;
using MachineStatusesTracker.Commands;
using MachineStatusesTracker.Models;

namespace MachineStatusesTracker.ViewModel
{
    public class AddMachineViewModel : BaseViewModel
    {
        public ICommand AddMachineCommand { get; set; }

        public Action? CloseAction { get; set; }

        public string? MachineName { get; set; }

        public Status? MachineStatus { get; set; }

        public string? ValidationMessage { get; set; }

        public AddMachineViewModel()
        {
            AddMachineCommand = new RelayCommand(AddMachine, CanAddMachine);
        }

        private bool CanAddMachine(object obj)
        {
            return true;
        }

        private void AddMachine(object obj)
        {
            if (string.IsNullOrEmpty(MachineName))
            {
                ValidationMessage = "Machine name is empty";
                NotifyPropertyChanged("ValidationMessage");
                return;
            }
            else if (MachineStatus == null)
            {
                ValidationMessage = "Machine status is empty";
                NotifyPropertyChanged("ValidationMessage");
                return;
            }

            var logoSrc = $"/Views/Logos/{MachineStatus}.png";

            MachineManager.AddMachine(new Machine()
            {
                Name = MachineName,
                Status = MachineStatus,
                LogoSrc = logoSrc
            });

            if (CloseAction != null)
            {
                CloseAction();
            }
        }
    }
}
