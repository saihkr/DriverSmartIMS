using DriverSmartIMS.Interfaces;
using DriverSmartIMS.Services;
using DriverSmartIMS.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriverSmartIMS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.RegisterSingleton<IFileStorage>(new FileStorageService());
            DependencyService.RegisterSingleton<IDriverService>(new DriverService());

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
