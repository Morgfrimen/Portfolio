using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Annotations;

namespace WpfApp.ViewModels
{
    public class BaseViewModels : INotifyPropertyChanged
    {
        protected BaseViewModels() { }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName: propertyName));
        }
    }
}