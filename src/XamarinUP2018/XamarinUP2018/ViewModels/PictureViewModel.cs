using Prism.Navigation;
using XamarinUP2018.Models;

namespace XamarinUP2018.ViewModels
{
    class PictureViewModel : ViewModelBase
    {
        UnsplashPicture _picture;
        public UnsplashPicture Picture
        {
            get { return _picture; }
            set { SetProperty(ref _picture, value); }
        }

        public PictureViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            Picture = (UnsplashPicture)parameters["picture"];
            if (Picture.Description == null)
                Picture.Description = Picture.AltDescription;
        }
    }
}
