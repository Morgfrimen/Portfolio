using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApp.Annotations;
using WpfApp.View;

namespace WpfApp.ViewModels
{
    public class BaseViewModels : INotifyPropertyChanged
    {
        private readonly Discriminant _discriminant;
        private readonly DefaultPageMainFrame _defaultPage;
        public BaseViewModels()
        {
            _discriminant=new Discriminant();
            _defaultPage = new DefaultPageMainFrame();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public Discriminant Discriminant1
        {
            get { return _discriminant; }
        }

        public DefaultPageMainFrame DefaultPage
        {
            get { return _defaultPage; }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName: propertyName));
        }
    }
}