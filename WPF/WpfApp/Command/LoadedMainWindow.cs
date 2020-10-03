using System;
using System.Windows.Input;

namespace WpfApp.Command
{
    public class LoadedMainWindow : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true; //TODO!
        }

        public void Execute(object parameter)
        {
            parameter = $"{nameof(LoadedMainWindow)}!!!!";
        }

        public event EventHandler CanExecuteChanged;
    }
}