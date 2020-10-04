using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Annotations;
using WpfApp.View;

namespace WpfApp.ViewModels
{
    public class BaseViewModels : INotifyPropertyChanged
    {
        public BaseViewModels()
        {
            Discriminant1 = new Discriminant();
        }

        public Discriminant Discriminant1 { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName: propertyName));
        }
    }
}