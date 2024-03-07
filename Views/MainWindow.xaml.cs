using System.Windows;
using MachineStatusesTracker.Models;
using MachineStatusesTracker.ViewModel;

namespace MachineStatusesTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
        }

        private void filterMachineStatuses_TextChanged(object sender, RoutedEventArgs e)
        {
            icMachineStatuses.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            var machine = (Machine)obj;
            return machine.Status.ToString().Contains(FilterMachineStatuses.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clonedMachinesList = new List<Machine>();
            if (icMachineStatuses.Items.Count > 0)
            {
                foreach (var machine in icMachineStatuses.Items)
                {
                    clonedMachinesList.Add((Machine)machine);
                }
                foreach (var machine in clonedMachinesList)
                {
                    MachineManager.DeleteMachine(machine);
                }
            }
        }
    }
}