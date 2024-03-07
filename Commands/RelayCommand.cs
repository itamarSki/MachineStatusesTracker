using System.Windows.Input;

namespace MachineStatusesTracker.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object> _Execute { get; set; }
        private Predicate<object> _CanEexcute { get; set; }

        public RelayCommand(Action<object> ExcuteMethod, Predicate<object> CanExcuteMethod)
        {
            _Execute = ExcuteMethod;
            _CanEexcute = CanExcuteMethod;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanEexcute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}
