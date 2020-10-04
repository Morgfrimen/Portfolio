using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp.Models.Navigate;
using WpfApp.View;

namespace WpfApp.Command
{
    public sealed class NavigatePageDiscriminant : ICommand
    {
        private readonly Discriminant _discriminant;
        private readonly DiscriminantCustomContentState _discriminantCustomContentState;

        private bool _canExecute;

        public NavigatePageDiscriminant(Discriminant discriminant,DefaultPageMainFrame defaultPageMainFrame)
        {
            _discriminant = discriminant;
            _discriminantCustomContentState = new DiscriminantCustomContentState(_discriminant, defaultPageMainFrame);
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
            _discriminantCustomContentState.Replay(nav, NavigationMode.New);

        }

        public event EventHandler CanExecuteChanged;
    }
}