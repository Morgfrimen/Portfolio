using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp.View;

namespace WpfApp.Command
{
    public sealed class NavigatePageDiscriminant : ICommand
    {
        private readonly bool _canExecute;
        private readonly Discriminant _discriminant;

        public NavigatePageDiscriminant()
        {
            _discriminant = new Discriminant();
            _canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute; //TODO:
        }

        public void Execute(object parameter)
        {
            Frame frame = parameter as Frame ?? throw new InvalidOperationException();

            NavigationService nav = frame.NavigationService;
            nav.Navigate(root: _discriminant, navigationState: "Квадратные уравнения!");
        }

        public event EventHandler CanExecuteChanged;
    }
}