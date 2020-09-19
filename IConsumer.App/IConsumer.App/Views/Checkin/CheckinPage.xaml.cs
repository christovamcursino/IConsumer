﻿using IConsumer.App.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IConsumer.App.Views.Checkin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckinPage : ContentPage
    {
        public CheckinPage()
        {
            InitializeComponent();
        }

        private async void ButtonCheckIn_Clicked(object sender, EventArgs e)
        {
            Guid tableId = Guid.Parse(EntryTableId.Text);

            var result = await App.AppService.DoCheckIn(tableId);

            if (result == false)
            {
                await DisplayAlert("Mesa inexistente!!!", "Esta mesa não está cadastrada, digite novamente!", "Ok");
                return;
            }

            var menuPage = new MenuPage();
            await menuPage.PopulateMenu();

            Navigation.InsertPageBefore(menuPage, this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}