using IConsumer.App.Views.Checkin;
using IConsumer.App.Views.OrderList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IConsumer.App.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabMainPage : TabbedPage
    {
        public TabMainPage()
        {
            InitializeComponent();
        }

        public async Task AddPages()
        {
            this.Children.Add(new CheckinPage() { Title = "Check IN", ParentPage = this });

            OrderListPage orderListPage = new OrderListPage { Title = "Meus Pedidos" };
            await orderListPage.ShowOrders();
            this.Children.Add(orderListPage);
        }
    }
}