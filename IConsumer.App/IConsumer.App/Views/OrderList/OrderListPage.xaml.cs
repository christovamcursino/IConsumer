using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IConsumer.App.Views.OrderList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderListPage : ContentPage
    {
        public IEnumerable<Order> Orders { get; set; }

        public OrderListPage()
        {
            InitializeComponent();
        }

        private async void ButtonRefresh_Clicked(object sender, EventArgs e)
        {
            BindingContext = null;
            await ShowOrders();
        }

        public async Task ShowOrders()
        {
            this.Orders = await App.AppService.GetCustomerOrders();           
            BindingContext = this;
        }
    }
}