using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jenx.AzureDevOps.MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Master.Icon = "icon.png";
        }
    }
}