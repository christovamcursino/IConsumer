using IConsumer.Microservices.Common.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _uow;
        private IOrderRepository _orderRepository;
        private IOrderStatusRepository _orderStatusRepository;

        public Order CreateOrder(Guid customerId, Guid tableId, ICollection<OrderItem> orderItems)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                CustomerId = customerId,
                OrderItems = orderItems
            };

            return order;
        }

        public async Task<IEnumerable<Order>> GetCustomerOrders(Guid customerId)
        {
            return await _orderRepository.ReadAllAsync
        }

        public IEnumerable<Order> GetStoreNewOrders(Guid storeId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ProcessOrderAsync(Order order)
        {
            _uow.BeginTransaction();
    
            await _orderRepository.CreateAsync(order);
            //var _return = await _orderRepository.SaveChangesAsync() > 0;

            return await _uow.SaveChangesAsync() > 0;
        }

        public Order SetOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            throw new NotImplementedException();
        }
    }
}
