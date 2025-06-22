using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlanTurismo.ViewModels
{
    public class SystemInfoViewModel
    {
        public string AppName { get; set; }
        public string PackageName { get; set; }
        public string AppVersion { get; set; }
        public string BuildNumber { get; set; }
        public string PackagingModel { get; set; }
        public string LayoutDirection { get; set; }
        public string CurrentTheme { get; set; }

        public SystemInfoViewModel()
        {
            LoadInfo();
        }

        private void LoadInfo()
        {
            AppName = AppInfo.Name;
            PackageName = AppInfo.PackageName;
            AppVersion = AppInfo.VersionString;
            BuildNumber = AppInfo.BuildString;
            PackagingModel = AppInfo.PackagingModel.ToString();
            LayoutDirection = AppInfo.RequestedLayoutDirection.ToString();
            CurrentTheme = AppInfo.RequestedTheme switch
            {
                AppTheme.Dark => "Tema Oscuro",
                AppTheme.Light => "Tema Claro",
                _ => "Tema Desconocido"
            };
        }
    }
}
