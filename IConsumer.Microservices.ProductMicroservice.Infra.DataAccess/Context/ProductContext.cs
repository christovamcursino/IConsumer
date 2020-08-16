using IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate;
using IConsumer.Microservices.ProductMicroservice.Infra.DataAccess.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProductMicroservice.Infra.DataAccess.Context
{
    public class ProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            String connectionString = Properties.Resources.db_connection_string;
            optionsBuilder
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Product");

            modelBuilder.Entity<Product>();
            modelBuilder.Entity<ProductType>();

            //Map
            modelBuilder.ApplyConfiguration(new ProductMap());

            //Seed Value Objects

            base.OnModelCreating(modelBuilder);
        }
    }
}
