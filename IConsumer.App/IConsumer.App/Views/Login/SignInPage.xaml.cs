using IConsumer.App.Views.Checkin;
using IConsumer.App.Views.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IConsumer.App.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private async void ButtonSignIn_Clicked(object sender, EventArgs e)
        {
            var result = App.AppService.SignIn(EntryUsername.Text, EntryPassword.Text);

            if (result == false)
            {
                await DisplayAlert("Usuário ou senha inválida!", "Usuário ou senha inválida, digite novamente!", "Ok");
                return;
            }

            //Navigation.InsertPageBefore(new CheckinPage(), this);

            TabMainPage pg = new TabMainPage();
            await pg.AddPages();
            Navigation.InsertPageBefore(pg, this);

            await Navigation.PopAsync().ConfigureAwait(false);
        }

        private void ButtonSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SignUpPage());
        }
    }
}