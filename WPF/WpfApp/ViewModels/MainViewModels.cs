using System.Windows.Input;
using WpfApp.Command;
using WpfApp.View;

namespace WpfApp.ViewModels
{
    public sealed class MainViewModels : BaseViewModels
    {
        /// <summary>
        ///     Статус происходящей работы
        /// </summary>
        private string _status;

        public MainViewModels()
        {
            ICommand loadedMainWindow = new LoadedMainWindow();
            loadedMainWindow.Execute(parameter: this);
            PageDiscriminant = new NavigatePageDiscriminant(Discriminant1, DefaultPage);
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

        /// <summary>
        ///     Команда с событием для выбора Page с квадратными уравнениями!
        /// </summary>
        public ICommand PageDiscriminant { get; }
    }
}