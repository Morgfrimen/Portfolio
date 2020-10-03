using System.Windows.Input;
using WpfApp.Command;

namespace WpfApp.ViewModels
{
    public sealed class MainViewModels : BaseViewModels
    {
        private readonly ICommand _loadedMainWindow;

        /// <summary>
        ///     Статус происходящей работы
        /// </summary>
        private string _status;

        public MainViewModels()
        {
            _loadedMainWindow = new LoadedMainWindow();
            _loadedMainWindow.Execute(this);
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