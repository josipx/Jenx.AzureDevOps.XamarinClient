﻿using Xamarin.Forms.Xaml;

namespace Jenx.AzureDevOps.MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ILoadingPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }
    }
}