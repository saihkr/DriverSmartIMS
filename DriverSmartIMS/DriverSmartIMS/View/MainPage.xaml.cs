using DriverSmartIMS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DriverSmartIMS.View
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            ((MainPageViewModel)BindingContext).Initialize();
            base.OnAppearing();
        }
    }
}
