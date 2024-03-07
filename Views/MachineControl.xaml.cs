using System.Windows;
using System.Windows.Media.Imaging;
using MachineStatusesTracker.Models;
using ComboBox = System.Windows.Controls.ComboBox;

namespace MachineStatusesTracker.Views
{
    /// <summary>
    /// Interaction logic for MachineControl.xaml
    /// </summary>
    public partial class MachineControl : System.Windows.Controls.UserControl
    {
        public MachineControl()
        {
            InitializeComponent();
            List<Status> statusListItems = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();
            cmbMachineStatuses.ItemsSource = statusListItems;
        }

        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = ((ComboBox)sender);
            var machineDataContext = ((Machine)comboBox.DataContext);
            if (string.IsNullOrEmpty(comboBox.SelectedValue?.ToString()))
            {
                return;
            }

            var selectedStatusString = comboBox.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(selectedStatusString))
            {
                switch (selectedStatusString)
                {
                    case nameof(Status.OFF):
                    case nameof(Status.ON):
                    case nameof(Status.MAINTENANCE):
                        var logoSrcFilenameNoExtension = System.IO.Path.GetFileNameWithoutExtension(machineDataContext.LogoSrc);
                        if (!string.IsNullOrEmpty(logoSrcFilenameNoExtension))
                        {
                            if (!logoSrcFilenameNoExtension.ToLower().Equals(selectedStatusString.ToLower()))
                            {
                                if(Enum.TryParse(selectedStatusString, out Status machineStatus))
                                { 
                                    machineDataContext.Status = machineStatus;
                                    MachineManager.ChangeMachineStatus(machineDataContext, selectedStatusString);
                                    logo.Source = new BitmapImage(new Uri(machineDataContext.LogoSrc, UriKind.Relative));
                                }
                            }
                        }
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
