using IConsumer.Microservices.OrderMicroservice.Application.CQRS.Commands;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.MicroServices.Common.Application.Interfaces.CQRS.Messaging;
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

        public Task<bool> ChangeOrderStatus(Guid storeId, Guid orderId, OrderStatus orderStatus)
        {
            return _orderService.SetOrderStatus(storeId, orderId, orderStatus);
        }

        public async Task<Order> CreateOrderAsync(Guid customerId, Guid tableId, ICollection<OrderItem> orderItems)
        {
            var order = _orderService.CreateOrder(customerId, tableId, orderItems);
            var processOrderCommand = new ProcessOrderCommand(order);
            await _bus.EnqueueAsync(processOrderCommand, ProcessOrderCommand.CommandQueueName);

            return order;
        }

        public async Task<IEnumerable<Order>> GetCustomerOpenedOrders(Guid customerId)
        {
            return await _orderService.GetCustomerOpenedOrders(customerId);
        }

        public async Task<IEnumerable<Order>> GetStoreNewOrders(Guid storeId)
        {
            return await _orderService.GetStoreNewOrders(storeId);
        }
    }
}
