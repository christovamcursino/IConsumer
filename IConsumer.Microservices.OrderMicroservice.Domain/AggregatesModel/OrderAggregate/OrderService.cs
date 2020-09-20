using IConsumer.Microservices.Common.Domain.UoW;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.PaymentAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.StoreAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusService _orderStatusService;
        private readonly IStoreTableQueryService _storeTableQueryService;
        private readonly IProductQueryService _productQueryService;

        private readonly IPaymentService _paymentService;

        public OrderService(IUnitOfWork uow, IOrderRepository orderRepository, IOrderStatusService orderStatusService, IStoreTableQueryService storeTableQueryService, IProductQueryService productQueryService, IPaymentService paymentService)
        {
            _uow = uow;
            _orderRepository = orderRepository;
            _orderStatusService = orderStatusService;
            _storeTableQueryService = storeTableQueryService;
            _productQueryService = productQueryService;
            _paymentService = paymentService;
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

        public async Task<IEnumerable<Order>> GetStoreOpenedOrders(Guid storeId)
        {
            return await _orderRepository.FilterStoreOpenedOrders(storeId);
        }

        public async Task<bool> ProcessOrderAsync(Order order)
        {
            //Recupera o ID da loja e os dados de cada produto
            StoreTable storeTable = await _storeTableQueryService.GetStoreTableAsync(order.TableId);
            order.StoreId = storeTable.StoreId;

            foreach(var item in order.OrderItems)
            {
                Product prod = await _productQueryService.GetProductAsync(item.ProductId);
                item.Price = prod.Price;
                item.ProductName = prod.Name;
            }

            _uow.BeginTransaction();
            await _orderRepository.CreateAsync(order);
            await _uow.SaveChangesAsync();

            var paidInvoiceId = await _paymentService.ExecutePayment(order.Id, order.CustomerId, getOrderTotal(order));

            if (paidInvoiceId != null)
            {
                //Invoice paid. Lets change order status
                order.PaymentApproved = true;
                order.PaymentId = paidInvoiceId.ToString();
                _orderRepository.Update(order);
                await _uow.SaveChangesAsync();
                await SetOrderStatus(order.StoreId, order.Id, OrderStatus.PaymentConfirmed);
                return true;
            }
            return false;
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

        private decimal getOrderTotal(Order order)
        {
            return order.OrderItems.Sum(o => o.Price * o.Amount);
        }
    }
}
