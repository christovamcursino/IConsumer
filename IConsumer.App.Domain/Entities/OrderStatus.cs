using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public enum OrderStatus : int
    {
        Created = 0,
        PaymentProcess = 1,
        PaymentConfirmed = 2,
        PaymentDenied = 3,
        Received = 4,
        Ready = 5,
        Delivered = 6,
        Cancelled = 7
    }
}
