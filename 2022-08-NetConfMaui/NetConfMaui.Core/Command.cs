using System.Windows.Input;

namespace NetConfMaui
{
    public class Command : ICommand
    {
        readonly Predicate<object>? _canExecute;
        readonly Action _execute;

        public Command(Action execute, Predicate<object>? canExecute = null)
        {

            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute(parameter);
        public void Execute(object parameter) => _execute();
    }
}
