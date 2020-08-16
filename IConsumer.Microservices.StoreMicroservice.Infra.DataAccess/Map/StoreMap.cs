using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Map
{
    public class StoreMap : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.OwnsOne(c => c.Address, address =>
            {
                address.Property(c => c.Street);
                address.Property(c => c.Town);
                address.Property(c => c.State);
                address.Property(c => c.Zip);
            });

            builder
                .HasMany(n => n.StoreTables)
                .WithOne(p => p.Store).HasForeignKey(f => f.StoreId);
        }
    }
}