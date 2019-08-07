using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinUP2018.Models;
using XamarinUP2018.Services;

namespace XamarinUP2018.ViewModels
{
    class PictureViewModel : ViewModelBase
    {
        private readonly IFavoriteService favoriteService;
        public ICommand FavoritePicture { get; }

        UnsplashPicture _picture;
        public UnsplashPicture Picture
        {
            get { return _picture; }
            set { SetProperty(ref _picture, value); }
        }

        bool _wasFavorited;
        public bool WasFavorited
        {
            get { return _wasFavorited; }
            set { SetProperty(ref _wasFavorited, value); }
        }

        public PictureViewModel(
            INavigationService navigationService
            , IFavoriteService favoriteService) : base(navigationService)
        {
            this.favoriteService = favoriteService;
            this.WasFavorited = false;
            this.FavoritePicture = new DelegateCommand(async () => await FavoriteExecute())
                .ObservesCanExecute(() => IsNotBusy);
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            Picture = (UnsplashPicture)parameters["picture"];
            if (Picture.Description == null)
                Picture.Description = Picture.AltDescription;
            await LoadIsFavorited();
        }

        private async Task LoadIsFavorited()
        {
            await ExecuteBusyAction(async () =>
            {
                WasFavorited = await favoriteService.Exists(Picture);
            });
        }

        private async Task FavoriteExecute()
        {
            await ExecuteBusyAction(async () =>
            {
                // The button change WasFavorited's value first and so call this event
                if (WasFavorited)
                    await favoriteService.Add(Picture);
                else
                    await favoriteService.Delete(Picture);

                // Refeshing the button
                await LoadIsFavorited();
            });
        }
    }
}
