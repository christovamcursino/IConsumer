using IConsumer.Microservices.Common.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderStatusService : IOrderStatusService
    {
        private IUnitOfWork _uow;
        private IOrderStatusRepository _orderStatusRepository;
        private IOrderTrackingRepository _orderTrackingRepository;

        public OrderStatusService(IUnitOfWork uow, IOrderStatusRepository orderStatusRepository, IOrderTrackingRepository orderTrackingRepository)
        {
            _uow = uow;
            _orderStatusRepository = orderStatusRepository;
            _orderTrackingRepository = orderTrackingRepository;
        }

        public void AddTracking(Guid orderId, OrderStatus orderStatus)
        {
            _uow.BeginTransaction();
            OrderTracking tracking = new OrderTracking();
            tracking.Id = Guid.NewGuid();
            tracking.OrderId = orderId;
            tracking.OrderStatus = orderStatus;
            tracking.TrackingDate = DateTime.Now;

            _orderTrackingRepository.Insert(tracking);
            _uow.Commit();
        }

        public IEnumerable<OrderStatus> GetStatusList()
        {
            return _orderStatusRepository.GetAll();
        }
    }
}
