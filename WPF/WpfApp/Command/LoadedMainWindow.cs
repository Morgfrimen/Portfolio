using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Command
{
    public sealed class LoadedMainWindow : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (!(parameter is MainViewModels mainVm))
                throw new ArgumentNullException(paramName: nameof(mainVm));

            await Task.Run
            (
                action: async () =>
                {
                    await Task.Delay(delay: new TimeSpan(hours: 0, minutes: 0, seconds: 10));
                    mainVm.Status = $"Асинхронная задача выполнена! Приложение готово к работе!";
                }
            );
        }

        public event EventHandler CanExecuteChanged;
    }
}