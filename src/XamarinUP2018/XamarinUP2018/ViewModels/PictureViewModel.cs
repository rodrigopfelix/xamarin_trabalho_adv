using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using XamarinUP2018.Models;

namespace XamarinUP2018.ViewModels
{
    class PictureViewModel : ViewModelBase
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public PictureViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            UnsplashPicture unsplashPicture = (UnsplashPicture)parameters["picture"];
            Name = "Imagem de " + unsplashPicture.User.Name;
        }
    }
}
