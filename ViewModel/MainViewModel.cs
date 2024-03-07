using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MachineStatusesTracker.Commands;
using MachineStatusesTracker.Models;
using MachineStatusesTracker.Views;

namespace MachineStatusesTracker.ViewModel
{
    public class MainViewModel
    {

        public ObservableCollection<Models.Machine> Machines { get; set; }

        public ICommand ShowWindowCommand { get; set; }

        public MainViewModel()
        {
            Machines = MachineManager.GetMachines();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        public bool CanShowWindow(object obj)
        {
            return true;
        }

        public void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;

            AddMachine addMachineWin = new AddMachine();
            addMachineWin.Owner = mainWindow;
            addMachineWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addMachineWin.Show();
        }
    }
}
