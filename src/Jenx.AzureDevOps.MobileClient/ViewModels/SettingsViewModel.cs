using Jenx.AzureDevOps.Client;
using Jenx.AzureDevOps.MobileClient.Services;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace Jenx.AzureDevOps.MobileClient.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IAzureDevOpsSettings _azureDevOpsSettings;

        public SettingsViewModel(IAzureDevOpsSettings azureDevOpsSettings, ILoadingDialogService loadingDialogService) : base(loadingDialogService)
        {
            _azureDevOpsSettings = azureDevOpsSettings;
            Title = "Settings";
        }

        private string _personalAccessToken = string.Empty;

        public string PersonalAccessToken
        {
            get => _personalAccessToken;
            set => SetProperty(ref _personalAccessToken, value);
        }

        private string _organizationName = string.Empty;

        public string OrganizationName
        {
            get => _organizationName;
            set => SetProperty(ref _organizationName, value);
        }

        public ICommand SaveDataCommand => new Command(() =>
        {
            _azureDevOpsSettings.OrganizationName = OrganizationName;
            _azureDevOpsSettings.PersonalAccessToken = PersonalAccessToken;
        });

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsBusy = true;
            try
            {
                OrganizationName = _azureDevOpsSettings.OrganizationName;
                PersonalAccessToken = _azureDevOpsSettings.PersonalAccessToken;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}