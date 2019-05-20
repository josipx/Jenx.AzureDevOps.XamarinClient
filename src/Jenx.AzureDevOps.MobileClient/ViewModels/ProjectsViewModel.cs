using Jenx.AzureDevOps.Client;
using Jenx.AzureDevOps.Client.Models;
using Jenx.AzureDevOps.MobileClient.Services;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Jenx.AzureDevOps.MobileClient.ViewModels
{
    public class ProjectsViewModel : BaseViewModel
    {
        private readonly IAzureDevOpsService _azureDevOpsService;
        private readonly INavigationService _navigationService;
        private readonly IAzureDevOpsSettings _azureDevOpsSettings;

        public ProjectsViewModel(INavigationService navigationService, IAzureDevOpsService azureDevOpsService, IAzureDevOpsSettings azureDevOpsSettings, ILoadingDialogService loadingDialogService) : base(loadingDialogService)
        {
            _azureDevOpsService = azureDevOpsService;
            _navigationService = navigationService;
            _azureDevOpsSettings = azureDevOpsSettings;
            Title = "Projects";
        }

        public ICommand ShowRepositoriesCommand => new Command<string>(async (projectName) =>
        {
            await _navigationService.NavigateAsync($"RepositoriesPage?projectname={projectName}");
        });

        public ICommand ShowBuildsCommand => new Command<string>(async (projectName) =>
        {
            await _navigationService.NavigateAsync($"BuildsPage?projectname={projectName}");
        });

        public ICommand ShowBuildDefinitionsCommand => new Command<string>(async (projectName) =>
        {
            await _navigationService.NavigateAsync($"BuildDefinitionsPage?projectname={projectName}");
        });

        private ObservableCollection<Project> _projects = new ObservableCollection<Project>();

        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set => SetProperty(ref _projects, value);
        }

        private string _organization;

        public string Organization
        {
            get => _organization;
            set => SetProperty(ref _organization, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsBusy = true;
            try
            {
                Organization = _azureDevOpsSettings.OrganizationName;

                var proj = await _azureDevOpsService.GetProjectsAsync();
                Projects = new ObservableCollection<Project>(proj.Projects);
            }
            catch
            {
                Projects = new ObservableCollection<Project>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}