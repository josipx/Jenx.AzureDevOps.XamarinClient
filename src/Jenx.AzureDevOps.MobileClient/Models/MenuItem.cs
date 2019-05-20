using System;

namespace Jenx.AzureDevOps.MobileClient.Models
{
    public class MenuItem
    {
        public MenuItem()
        {
            IsMenuItemEnabled = true;
        }

        public string Title { get; set; }

        public double TitleOpacity { get; set; }

        public bool IsMenuItemEnabled { get; set; }

        public string Icon { get; set; }

        public Action OnMenuItemClickedAction { get; set; }
    }
}