using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroService.DataAccess.Repositories
{
    public class InvoiceRepository : RepositorySqlBase<Guid, Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext context) : base(context)
        {
        }
    }
}
