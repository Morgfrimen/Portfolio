using System.Windows.Input;
using WpfApp.Command;

namespace WpfApp.ViewModels
{
    public sealed class MainViewModels : BaseViewModels
    {
        private readonly RelayCommand _loadedMainWindow;

        /// <summary>
        ///     Статус происходящей работы
        /// </summary>
        private string _status;

        public MainViewModels()
        {
            _loadedMainWindow = new RelayCommand
            (
                action: () =>
                {
                    Status = "Сработало событие загрузки приложения!";
                }
            );
            _loadedMainWindow.Execute(Status);
        }

        /// <summary>
        ///     Статус происходящей работы
        /// </summary>
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(propertyName: nameof(Status));
            }
        }
    }
}