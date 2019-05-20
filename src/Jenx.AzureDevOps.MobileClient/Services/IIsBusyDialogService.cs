using System.Threading.Tasks;

namespace Jenx.AzureDevOps.MobileClient.Services
{
    public interface ILoadingDialogService
    {
        Task ShowIsBusy();

        Task HideIsBusy();
    }
}