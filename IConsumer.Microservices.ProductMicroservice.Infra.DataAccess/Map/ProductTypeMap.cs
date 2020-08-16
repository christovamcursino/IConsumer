using IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProductMicroservice.Infra.DataAccess.Map
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder
                .HasMany(n => n.Products)
                .WithOne(p => p.ProductType).HasForeignKey(f => f.ProductTypeId);
        }
    }
}
