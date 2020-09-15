using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.MicroServices.OrderMicroservice.Application.ViewModel
{
    public class ChangeStatusViewModel
    {
        public OrderStatus OrderStatus { get; set; }
    }
}
