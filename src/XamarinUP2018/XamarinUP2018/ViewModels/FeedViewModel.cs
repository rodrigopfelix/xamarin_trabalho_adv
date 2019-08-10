using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using XamarinUP2018.Models;
using XamarinUP2018.Services;
using XamarinUP2018.Views;

namespace XamarinUP2018.ViewModels
{
    public sealed class FeedViewModel : ViewModelBase
    {
        private readonly IUnsplashService unsplashService;
        public ICommand GoPicture { get; }
        public ICommand ListViewItemAppearing { get; }
        public ICommand RefreshCommand
        {
            get => new Command(async () =>
                {
                    ShowNoData = false;
                    IsBusy = true;

                    UpdateItens(await unsplashService.GetPictures());

                    IsBusy = false;
                });
        }

        private ObservableCollection<UnsplashPicture> items = new ObservableCollection<UnsplashPicture>();
        public ObservableCollection<UnsplashPicture> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private bool showNoData = false;
        public bool ShowNoData
        {
            get => showNoData;
            set => SetProperty(ref showNoData, value);
        }

        public FeedViewModel(INavigationService navigationService 
            , IUnsplashService unsplashService) 
            : base(navigationService)
        {
            this.unsplashService = unsplashService;
            this.GoPicture = new DelegateCommand<UnsplashPicture>(async (picture) => await ExecuteGoPicture(picture));
            this.ListViewItemAppearing = new DelegateCommand<UnsplashPicture>(async (picture) => await ExecuteListViewItemAppearingAsync(picture));
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            await LoadFeedItems();
        }

        private async Task LoadFeedItems(bool append = false)
        {
            await ExecuteBusyAction(async () => 
            {
                UpdateItens(await unsplashService.GetPictures(), append);
            });
        }

        private void UpdateItens(List<UnsplashPicture> itens, bool append = false)
        {
            if (!append)
                Items.Clear();

            ShowNoData = itens.Count == 0;

            foreach (var item in itens)
                Items.Add(item);
        }

        private Task ExecuteGoPicture(UnsplashPicture picture)
        {
            var param = new NavigationParameters();
            param.Add("picture", picture);

            return NavigationService.NavigateAsync($"{nameof(PicturePage)}", param);
        }

        private async Task ExecuteListViewItemAppearingAsync(UnsplashPicture picture)
        {
            if (IsNotBusy && Items.Count > 0 && picture.Id == Items[Items.Count - 1].Id)
                await LoadFeedItems(true);
        }
    }
}
