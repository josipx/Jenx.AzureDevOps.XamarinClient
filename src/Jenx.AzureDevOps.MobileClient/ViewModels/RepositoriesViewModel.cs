using Jenx.AzureDevOps.Client;
using Jenx.AzureDevOps.Client.Models;
using Jenx.AzureDevOps.MobileClient.Services;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Jenx.AzureDevOps.MobileClient.ViewModels
{
    public class RepositoriesViewModel : BaseViewModel
    {
        private readonly IAzureDevOpsService _azureDevOpsService;

        public RepositoriesViewModel(IAzureDevOpsService azureDevOpsService, ILoadingDialogService loadingDialogService) : base(loadingDialogService)
        {
            _azureDevOpsService = azureDevOpsService;
            Title = "Repositories";
        }

        private string _projectName;

        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }

        private ObservableCollection<Repos> _repositories = new ObservableCollection<Repos>();

        public ObservableCollection<Repos> Repositories
        {
            get => _repositories;
            set => SetProperty(ref _repositories, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsBusy = true;
            ProjectName = parameters["projectname"].ToString();

            try
            {
                var builds = await _azureDevOpsService.GetReposAsync(ProjectName);
                Repositories = new ObservableCollection<Repos>(builds.Repos);
            }
            catch
            {
                Repositories = new ObservableCollection<Repos>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}