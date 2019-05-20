using Jenx.AzureDevOps.MobileClient.Services;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MenuItem = Jenx.AzureDevOps.MobileClient.Models.MenuItem;

namespace Jenx.AzureDevOps.MobileClient.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService, ILoadingDialogService loadingDialogService) : base(loadingDialogService)
        {
            _navigationService = navigationService;
        }

        private ObservableCollection<MenuItem> _menuItems;

        public ObservableCollection<MenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public ICommand MenuSelectedCommand => new Command(async (selectedMenuItem) =>
        {
            var item = (MenuItem)selectedMenuItem;

            if (item.OnMenuItemClickedAction != null)
                await Task.Run(item.OnMenuItemClickedAction);

            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(350);

            MainMenuDisplayed = false;
        });

        private bool _mainMenuDisplayed;

        public bool MainMenuDisplayed
        {
            get => _mainMenuDisplayed;
            set => SetProperty(ref _mainMenuDisplayed, value);
        }

        #region Private

        private void SetMenu()
        {
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Title = "Projects",
                    Icon="projects.png",
                    OnMenuItemClickedAction =  ()=>
                    {
                         NavigateTo("ProjectsPage");
                    },
                    IsMenuItemEnabled = true,
                },
                new MenuItem
                {
                    Title = "Settings",
                    Icon="settings.png",
                    OnMenuItemClickedAction =  ()=>
                    {
                        NavigateTo("SettingsPage");
                    },
                    IsMenuItemEnabled = true
                },
                new MenuItem
                {
                    Title = "About",
                    Icon="about.png",
                    OnMenuItemClickedAction =  ()=>
                    {
                        NavigateTo("AboutPage");
                    },
                    IsMenuItemEnabled = true
                }
            };
        }

        private void NavigateTo(string page)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await _navigationService.NavigateAsync(new Uri($"/MainPage/NavigationPage/{page}", UriKind.Absolute));
            });
        }

        #endregion Private

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            SetMenu();
        }
    }
}