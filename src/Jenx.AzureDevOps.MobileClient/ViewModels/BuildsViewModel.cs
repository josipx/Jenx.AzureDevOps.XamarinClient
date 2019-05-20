using Jenx.AzureDevOps.Client;
using Jenx.AzureDevOps.Client.Models;
using Jenx.AzureDevOps.MobileClient.Services;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Jenx.AzureDevOps.MobileClient.ViewModels
{
    public class BuildsViewModel : BaseViewModel
    {
        private readonly IAzureDevOpsService _azureDevOpsService;

        public BuildsViewModel(IAzureDevOpsService azureDevOpsService, ILoadingDialogService loadingDialogService) : base(loadingDialogService)
        {
            _azureDevOpsService = azureDevOpsService;
            Title = "Builds";
        }

        private string _projectName;

        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }

        private ObservableCollection<Build> _builds = new ObservableCollection<Build>();

        public ObservableCollection<Build> Builds
        {
            get => _builds;
            set => SetProperty(ref _builds, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsBusy = true;
            ProjectName = parameters["projectname"].ToString();

            try
            {
                var builds = await _azureDevOpsService.GetProjectBuildsAsync(ProjectName);
                Builds = new ObservableCollection<Build>(builds.Builds);
            }
            catch
            {
                Builds = new ObservableCollection<Build>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}