using IConsumer.Microservices.Common.Domain.UoW;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.StoreAggregate;
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
        private IOrderStatusService _orderStatusService;
        private IStoreTableQueryService _storeTableQueryService;
        private IProductQueryService _productQueryService;

        public OrderService(IUnitOfWork uow, IOrderRepository orderRepository, IOrderStatusService orderStatusService, IStoreTableQueryService storeTableQueryService, IProductQueryService productQueryService)
        {
            _uow = uow;
            _orderRepository = orderRepository;
            _orderStatusService = orderStatusService;
            _storeTableQueryService = storeTableQueryService;
            _productQueryService = productQueryService;
        }

        public Order CreateOrder(Guid customerId, Guid tableId, ICollection<OrderItem> orderItems)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                TableId = tableId,
                OrderDate = DateTime.Now,
                CustomerId = customerId,
                OrderItems = orderItems,
                OrderStatus = OrderStatus.Created
            };

            return order;
        }

        public async Task<IEnumerable<Order>> GetCustomerClosedOrders(Guid customerId)
        {
            return await _orderRepository.FilterClosedOrdersOfCustomer(customerId);
        }

        public async Task<IEnumerable<Order>> GetCustomerOpenedOrders(Guid customerId)
        {
            return await _orderRepository.FilterOpenedOrdersOfCustomer(customerId);
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _orderRepository.ReadAsync(id);
        }

        public async Task<IEnumerable<Order>> GetStoreNewOrders(Guid storeId)
        {
            return await _orderRepository.FilterNewOrders(storeId);
        }

        public async Task<bool> ProcessOrderAsync(Order order)
        {
            //Recupera o ID da loja e os dados de cada produto
            StoreTable storeTable = await _storeTableQueryService.GetStoreTableAsync(order.TableId);
            order.StoreId = storeTable.Id;

            foreach(var item in order.OrderItems)
            {
                Product prod = await _productQueryService.GetProductAsync(item.ProductId);
                item.Price = prod.Price;
                item.ProductName = prod.Name;
            }

            _uow.BeginTransaction();
            await _orderRepository.CreateAsync(order);
            return await _uow.SaveChangesAsync() > 0;
            //TODO: enviar para pagamento
        }

        public async Task<bool> SetOrderStatus(Guid storeId, Guid orderId, OrderStatus orderStatus)
        {
            var order = await _orderRepository.ReadAsync(orderId);
            if (! order.StoreId.Equals(storeId))
            {
                //Pedido nao e da loja logada.
                return false;
            }
            _uow.BeginTransaction();
            order.OrderStatus = orderStatus;
            _orderRepository.Update(order);
            _orderStatusService.AddTracking(orderId, orderStatus);
            return await _uow.SaveChangesAsync() > 0;
        }
    }
}
