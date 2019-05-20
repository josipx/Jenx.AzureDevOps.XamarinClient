using Jenx.AzureDevOps.Client;
using Xamarin.Essentials;

namespace Jenx.AzureDevOps.MobileClient.Services
{
    public class AzureDevOpsSettingsService : IAzureDevOpsSettings
    {
        public string PersonalAccessToken
        {
            get => Preferences.Get(nameof(PersonalAccessToken), "");
            set => Preferences.Set(nameof(PersonalAccessToken), value);
        }

        public string OrganizationName
        {
            get => Preferences.Get(nameof(OrganizationName), "");
            set => Preferences.Set(nameof(OrganizationName), value);
        }
    }
}