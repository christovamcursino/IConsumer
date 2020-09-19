using IConsumer.App.Domain.Entities;
using IConsumer.App.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IConsumer.App.Views.AddItem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public Product ChoosenProduct { get; set; }

        public AddItemPage()
        {
            InitializeComponent();
        }

        public void ShowProduct(Product product)
        {
            this.ChoosenProduct = product;
            LabelProductName.Text = product.Name;
            EntryAmount.Text = "1";
        }

        private async void ButtonAddToCart_Clicked(object sender, EventArgs e)
        {
            int amount = int.Parse(EntryAmount.Text);

            App.AppService.AddProductToCart(this.ChoosenProduct, amount);

            var menuPage = new MenuPage();
            await menuPage.PopulateMenu();

            Navigation.InsertPageBefore(menuPage, this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}