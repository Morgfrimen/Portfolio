using System.Windows.Input;
using WpfApp.Command.DiscriminantPage;

namespace WpfApp.ViewModels
{
    public sealed class DiscriminantViewModels : BaseViewModels
    {
        /// <summary>
        ///     Коэффициент а
        /// </summary>
        private double _a;

        /// <summary>
        ///     Коэффициент b
        /// </summary>
        private double _b;

        /// <summary>
        ///     Коэффициент c
        /// </summary>
        private double _c;

        private string _contentButtonRunDiscriminant = "Посчитать";

        /// <summary>
        ///     Результат
        /// </summary>
        private double _result;

        private string _resultRun;

        public DiscriminantViewModels()
        {
            RunDiscriminantCommand = new RunDiscriminant();
        }

        /// <summary>
        ///     Коэффициент а
        /// </summary>
        public double A
        {
            get { return _a; }
            set
            {
                _a = value;
                OnPropertyChanged(propertyName: nameof(A));
            }
        }

        /// <summary>
        ///     Коэффициент b
        /// </summary>
        public double B
        {
            get { return _b; }
            set
            {
                _b = value;
                OnPropertyChanged(propertyName: nameof(B));
            }
        }

        /// <summary>
        ///     Коэффициент c
        /// </summary>
        public double C
        {
            get { return _c; }
            set
            {
                _c = value;
                OnPropertyChanged(propertyName: nameof(C));
            }
        }

        /// <summary>
        ///     Результат
        /// </summary>
        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(propertyName: nameof(Result));
            }
        }

        // ReSharper disable once ConvertToAutoProperty
        public string ContentButtonRunDiscriminant
        {
            get { return _contentButtonRunDiscriminant; }
            set
            {
                _contentButtonRunDiscriminant = value;
                OnPropertyChanged(propertyName: nameof(ContentButtonRunDiscriminant));
            }
        }

        public string ResultRun
        {
            get { return _resultRun; }
            set
            {
                _resultRun = value;
                OnPropertyChanged(propertyName: nameof(ResultRun));
            }
        }

        public ICommand RunDiscriminantCommand { get; }
    }
}