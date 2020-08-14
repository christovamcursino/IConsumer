using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
    }
}
