using Jenx.AzureDevOps.MobileClient.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;

namespace Jenx.AzureDevOps.MobileClient.Services
{
    public class LoadingDialogService : ILoadingDialogService
    {
        private readonly ILoadingPage _page;

        public LoadingDialogService(ILoadingPage page)
        {
            _page = page;
        }

        public async Task ShowIsBusy()
        {
            await PopupNavigation.Instance.PushAsync((PopupPage)_page);
        }

        public async Task HideIsBusy()
        {
            await PopupNavigation.Instance.PopAllAsync(false);
        }
    }
}