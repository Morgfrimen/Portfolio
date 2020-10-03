#nullable enable
using System;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.Command
{
    public sealed class NavigatePageDiscriminant : ICommand
    {
        public bool CanExecute(object? parameter)
        {
            return true; //TODO:
        }

        public void Execute(object? parameter)
        {
            MessageBox.Show(messageBoxText: "ВЫШЛО!");
        }

        public event EventHandler? CanExecuteChanged;
    }
}