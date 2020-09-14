using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Repositories
{
    public class OrderRepository : ASyncRepositorySqlBase<Guid, Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> FilterNewOrders(Guid storeId)
        {
            return await _context.Set<Order>()
                .Where(o => o.StoreId.Equals(storeId) && o.OrderStatus.Equals(OrderStatus.PaymentConfirmed))
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> FilterOpenedOrdersOfCustomer(Guid customerId)
        {
            return await _context.Set<Order>()
                .Where(o => o.CustomerId.Equals(customerId) && !(
                        o.OrderStatus.Equals(OrderStatus.Delivered) || o.OrderStatus.Equals(OrderStatus.Cancelled)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> FilterClosedOrdersOfCustomer(Guid customerId)
        {
            return await _context.Set<Order>()
                .Where(o => o.CustomerId.Equals(customerId) && (
                        o.OrderStatus.Equals(OrderStatus.Delivered) || o.OrderStatus.Equals(OrderStatus.Cancelled)))
                .ToListAsync();
        }
    }
}
