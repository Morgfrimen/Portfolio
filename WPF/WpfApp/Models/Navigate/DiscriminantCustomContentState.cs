using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp.View;

namespace WpfApp.Models.Navigate
{
    [Serializable]
    public sealed class DiscriminantCustomContentState : CustomContentState
    {
        private readonly DefaultPageMainFrame _defaultPage;
        private readonly Page _page;

        public DiscriminantCustomContentState(Page page, DefaultPageMainFrame defaultPage)
        {
            JournalEntryName = "Квадратные уравнения";
            _page = page;
            _defaultPage = defaultPage;
        }

        public override string JournalEntryName { get; }

        public override void Replay(NavigationService navigationService, NavigationMode mode)
        {
            switch (mode)
            {
                case NavigationMode.Back:
                    navigationService.Navigate(root: _defaultPage);
                    navigationService.RemoveBackEntry();

                    break;

                case NavigationMode.New:
                    navigationService.Navigate(root: _page,this);
                    navigationService.RemoveBackEntry();
                    break;

                case NavigationMode.Forward:
                    navigationService.Navigate(root: _page);

                    break;

                case NavigationMode.Refresh:
                    navigationService.Refresh();
                    break;
            }
        }
    }
}