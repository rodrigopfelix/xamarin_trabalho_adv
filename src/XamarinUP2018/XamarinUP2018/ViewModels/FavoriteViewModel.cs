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
    public sealed class FavoriteViewModel : ViewModelBase
    {
        private readonly IFavoriteService favoriteService;
        public ICommand GoPicture { get; }
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

        public FavoriteViewModel(INavigationService navigationService
            , IFavoriteService favoriteService)
            : base(navigationService)
        {
            this.favoriteService = favoriteService;
            this.GoPicture = new DelegateCommand<UnsplashPicture>(async (picture) => await ExecuteGoPicture(picture));
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            await LoadFavoriteds();
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await LoadFavoriteds();
        }

        private async Task LoadFavoriteds()
        {
            await ExecuteBusyAction(async () =>
            {
                UpdateItens(await favoriteService.GetAll());
            });
        }

        private void UpdateItens(List<UnsplashPicture> itens)
        {
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

        public ICommand RefreshCommand
        {
            get => new Command(async () =>
                {
                    ShowNoData = false;
                    IsBusy = true;

                    UpdateItens(await favoriteService.GetAll());

                    IsBusy = false;
                });
        }
    }
}
