using IConsumer.App.Application;
using IConsumer.App.Application.Interfaces;
using IConsumer.App.Views.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IConsumer.App
{
    public partial class App : Xamarin.Forms.Application
    {
        public static IAppCustomerService AppService { get; set; }

        public App()
        {
            InitializeComponent();
            AppService = new CustomerMobileService();

            MainPage = new NavigationPage(new SignInPage());
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
