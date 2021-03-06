﻿using IConsumer.Microservices.OrderMicroservice.Application.CQRS.Commands;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.MicroServices.Common.Application.Interfaces.CQRS.Messaging;
using IConsumer.MicroServices.OrderMicroservice.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.MicroServices.OrderMicroservice.Application.Services
{
    public class ApiApplicationService : IApiApplicationService
    {
        private readonly IOrderService _orderService;
        private readonly IMediatorHandler _bus;

        public ApiApplicationService(IOrderService orderService, IMediatorHandler mediatorHandler)
        {
            this._orderService = orderService;
            _bus = mediatorHandler;
        }

        public Task<bool> ChangeOrderStatus(Guid storeId, Guid orderId, ChangeStatusViewModel orderStatus)
        {
            return _orderService.SetOrderStatus(storeId, orderId, orderStatus.OrderStatus);
        }

        public async Task<Order> CreateOrderAsync(Guid customerId, Guid tableId, CreateOrderViewModel orderViewModel)
        {
            ICollection<OrderItem> orderItems = new List<OrderItem>();
            foreach(var item in orderViewModel.OrderItems) 
            {
                orderItems.Add(new OrderItem { 
                    Id = Guid.NewGuid(), ProductId = item.ProductId, Amount = item.Amount 
                });
            }

            var order = _orderService.CreateOrder(customerId, tableId, orderItems);
            var processOrderCommand = new ProcessOrderCommand(order);
            await _bus.EnqueueAsync(processOrderCommand, ProcessOrderCommand.CommandQueueName);

            return order;
        }

        public async Task<IEnumerable<Order>> GetCustomerOpenedOrders(Guid customerId)
        {
            return await _orderService.GetCustomerOpenedOrders(customerId);
        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            return await _orderService.GetOrder(orderId);
        }

        public async Task<IEnumerable<Order>> GetStoreNewOrders(Guid storeId)
        {
            return await _orderService.GetStoreNewOrders(storeId);
        }

        public async Task<IEnumerable<Order>> GetStoreOpenedOrders(Guid storeId)
        {
            return await _orderService.GetStoreOpenedOrders(storeId);
        }
    }
}
