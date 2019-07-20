using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinUP2018.Services;
using XamarinUP2018.ViewModels;
using XamarinUP2018.Views;

namespace XamarinUP2018
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(OnBoardingPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFeedService, FeedService>();

            containerRegistry.RegisterForNavigation<NavigationPage>(nameof(NavigationPage));
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>(nameof(HomePage));
            containerRegistry.RegisterForNavigation<OnBoardingPage, OnBoardingViewModel>(nameof(OnBoardingPage));
            containerRegistry.RegisterForNavigation<FeedPage, FeedViewModel>(nameof(FeedPage));
            containerRegistry.RegisterForNavigation<HistoryPage, HistoryViewModel>(nameof(HistoryPage));
            containerRegistry.RegisterForNavigation<AboutPage, AboutViewModel>(nameof(AboutPage));
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
