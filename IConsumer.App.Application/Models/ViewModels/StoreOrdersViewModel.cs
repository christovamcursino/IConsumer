using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Application.Models.ViewModels
{
    public class StoreOrdersViewModel
    {
        public string StoreName { get; set; }
        public IEnumerable<Order> OpenedOrders { get; set; }
    }
}

