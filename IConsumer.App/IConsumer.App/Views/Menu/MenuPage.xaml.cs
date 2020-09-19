using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IConsumer.App.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Grouping<ProductType, Product>> MenuList { get; set; } = new ObservableCollection<Grouping<ProductType, Product>>();

        public MenuPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public async Task PopulateMenu()
        {
            LabelWelcome.Text = App.AppService.CurrentStore.Name;

            IEnumerable<ProductType> Menu = await App.AppService.GetMenu();

            foreach(ProductType menuType in Menu)
            {
                var group = new Grouping<ProductType, Product>(menuType, menuType.Products);
                MenuList.Add(group);
            }

        }
    }
}