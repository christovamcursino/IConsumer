using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Map
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasMany(n => n.TrackingHistory)
                .WithOne(p => p.Order).HasForeignKey(f => f.OrderId);

            builder
                .HasMany(n => n.OrderItens)
                .WithOne(p => p.Order).HasForeignKey(f => f.OrderId);
        }
    }
}
