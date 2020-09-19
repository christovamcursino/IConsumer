using IConsumer.App.Domain.Entities;
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

        public CheckoutPage()
        {
            InitializeComponent();
            ShowCart();
        }

        private void ShowCart()
        {
            this.Cart = App.AppService.Cart;
            BindingContext = this;
        }
    }
}