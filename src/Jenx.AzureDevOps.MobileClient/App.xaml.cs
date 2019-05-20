using Jenx.AzureDevOps.Client;
using Jenx.AzureDevOps.MobileClient.Services;
using Jenx.AzureDevOps.MobileClient.ViewModels;
using Jenx.AzureDevOps.MobileClient.Views;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Jenx.AzureDevOps.MobileClient
{
    public partial class App
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(
                new Uri("/MainPage/NavigationPage/ProjectsPage", UriKind.Absolute));
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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Prism.Navigation.INavigationService, Prism.Navigation.PageNavigationService>();

            containerRegistry.RegisterSingleton<IAzureDevOpsSettings, AzureDevOpsSettingsService>();
            containerRegistry.Register<IAzureDevOpsService, AzureDevOpsService>();

            containerRegistry.RegisterSingleton<ILoadingPage, LoadingPage>();
            containerRegistry.RegisterSingleton<ILoadingDialogService, LoadingDialogService>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ProjectsPage, ProjectsViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<BuildsPage, BuildsViewModel>();
            containerRegistry.RegisterForNavigation<RepositoriesPage, RepositoriesViewModel>();
            containerRegistry.RegisterForNavigation<BuildDefinitionsPage, BuildDefinitionsViewModel>();

            containerRegistry.RegisterForNavigation<AboutPage, AboutViewModel>();
        }
    }
}