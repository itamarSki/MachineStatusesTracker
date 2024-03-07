using System.Windows;
using MachineStatusesTracker.Models;
using MachineStatusesTracker.ViewModel;

namespace MachineStatusesTracker.Views
{
    /// <summary>
    /// Interaction logic for AddMachine.xaml
    /// </summary>
    public partial class AddMachine : Window
    {
        public AddMachine()
        {
            InitializeComponent();

            List<Status> statusListItems = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();
            cmbMachineStatuses.ItemsSource = statusListItems;

            AddMachineViewModel addMachineViewModel = new AddMachineViewModel();

            if (addMachineViewModel.CloseAction == null)
            {
                addMachineViewModel.CloseAction = new Action(this.Close);
            }

            this.DataContext = addMachineViewModel;
        }
    }
}