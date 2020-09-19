using IConsumer.App.Domain.Entities;
using IConsumer.App.Views.Checkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IConsumer.App.Views.CheckOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckoutPage : ContentPage
    {
        public IList<OrderItem> Cart { get; set; }
        public decimal OrderTotal;

        public CheckoutPage()
        {
            InitializeComponent();
            ShowCart();
        }

        private void ShowCart()
        {
            this.Cart = App.AppService.Cart;
            this.OrderTotal = App.AppService.GetCartTotal();
            LabelOrderTotal.Text = $"Total do pedido: {OrderTotal}";
            BindingContext = this;
        }

        private async void ButtonCreateOrder_Clicked(object sender, EventArgs e)
        {
            await App.AppService.CreateOrder();

            Navigation.InsertPageBefore(new CheckinPage(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}