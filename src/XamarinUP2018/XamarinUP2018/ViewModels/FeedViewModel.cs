using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using XamarinUP2018.Models;
using XamarinUP2018.Services;

namespace XamarinUP2018.ViewModels
{
    public sealed class FeedViewModel : ViewModelBase
    {
        private readonly IFeedService feedService;

        public FeedViewModel(INavigationService navigationService 
            , IFeedService feedService) 
            : base(navigationService)
        {
            this.feedService = feedService;
        }

        private ObservableCollection<FeedItem> items = new ObservableCollection<FeedItem>();

        public ObservableCollection<FeedItem> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            await LoadFeedItems();
        }

        private async Task LoadFeedItems()
        {
            await ExecuteBusyAction(async () => {

                var feedItems = await feedService.GetFeedItems();

                Items.Clear();

                foreach (var item in feedItems)
                {
                    Items.Add(item);
                }

            });
        }
    }
}
