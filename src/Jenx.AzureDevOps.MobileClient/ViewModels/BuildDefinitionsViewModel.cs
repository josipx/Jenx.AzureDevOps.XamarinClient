using Jenx.AzureDevOps.Client;
using Jenx.AzureDevOps.Client.Models;
using Jenx.AzureDevOps.MobileClient.Services;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Jenx.AzureDevOps.MobileClient.ViewModels
{
    public class BuildDefinitionsViewModel : BaseViewModel
    {
        private readonly IAzureDevOpsService _azureDevOpsService;

        public BuildDefinitionsViewModel(IAzureDevOpsService azureDevOpsService, ILoadingDialogService loadingDialogService) : base(loadingDialogService)
        {
            _azureDevOpsService = azureDevOpsService;
            Title = "Build definitions";
        }

        private string _projectName;

        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }

        private ObservableCollection<Value> _buildDefinitions = new ObservableCollection<Value>();

        public ObservableCollection<Value> BuildDefinitions
        {
            get => _buildDefinitions;
            set => SetProperty(ref _buildDefinitions, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsBusy = true;
            ProjectName = parameters["projectname"].ToString();

            try
            {
                var buildDefinitions = await _azureDevOpsService.GetProjectBuildDefinitionsAsync(ProjectName);
                BuildDefinitions = new ObservableCollection<Value>(buildDefinitions.BuildDefinitions);
            }
            catch
            {
                BuildDefinitions = new ObservableCollection<Value>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}