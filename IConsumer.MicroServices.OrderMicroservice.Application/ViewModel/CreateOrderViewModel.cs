using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.MicroServices.OrderMicroservice.Application.ViewModel
{
    public class CreateOrderViewModel
    {
        public IEnumerable<CreateOrderItemViewModel> OrderItems { get; set; }
    }

    public class CreateOrderItemViewModel
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }
}
