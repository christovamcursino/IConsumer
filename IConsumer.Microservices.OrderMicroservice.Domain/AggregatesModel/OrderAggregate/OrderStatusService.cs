using IConsumer.Microservices.Common.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderStatusService : IOrderStatusService
    {
        private IUnitOfWork _uow;
        private IOrderTrackingRepository _orderTrackingRepository;

        public OrderStatusService(IUnitOfWork uow, IOrderTrackingRepository orderTrackingRepository)
        {
            _uow = uow;
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
    }
}
