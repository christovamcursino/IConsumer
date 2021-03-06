﻿using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.MicroServices.OrderMicroservice.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.MicroServices.OrderMicroservice.Application.Services
{
    public interface IApiApplicationService
    {
        Task<Order> CreateOrderAsync(Guid customerId, Guid tableId, CreateOrderViewModel orderViewModel);

        Task<IEnumerable<Order>> GetCustomerOpenedOrders(Guid customerId);
        Task<IEnumerable<Order>> GetStoreNewOrders(Guid storeId);
        Task<IEnumerable<Order>> GetStoreOpenedOrders(Guid storeId);
        Task<bool> ChangeOrderStatus(Guid storeId, Guid orderId, ChangeStatusViewModel orderStatus);

        Task<Order> GetOrder(Guid orderId);
    }
}
