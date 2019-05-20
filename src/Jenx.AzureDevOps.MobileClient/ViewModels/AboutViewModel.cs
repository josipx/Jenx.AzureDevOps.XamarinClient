using System.Windows.Input;
using Jenx.AzureDevOps.MobileClient.Services;
using Xamarin.Forms;

namespace Jenx.AzureDevOps.MobileClient.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(ILoadingDialogService loadingDialogService) : base(loadingDialogService)
        {
            Title = "About";
        }

        public ICommand OpenJenxSiWebCommand => new Command(() =>
        {
            Device.OpenUri(new System.Uri("https://www.jenx.si"));
        });
    }
}