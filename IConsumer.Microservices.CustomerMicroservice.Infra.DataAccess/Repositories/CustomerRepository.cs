using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.CustomerMicroservice.Infra.DataAccess.Repositories
{
    public class CustomerRepository : RepositorySqlBase<Guid, Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
