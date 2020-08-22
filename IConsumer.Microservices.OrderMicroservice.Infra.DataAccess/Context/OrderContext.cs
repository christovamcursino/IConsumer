using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Context
{
    public class OrderContext : DbContext
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
            modelBuilder.HasDefaultSchema("Order");

            modelBuilder.Entity<Order>();
            modelBuilder.Entity<OrderItem>();
            modelBuilder.Entity<OrderStatus>();
            modelBuilder.Entity<OrderTracking>();

            //Map
            modelBuilder.ApplyConfiguration(new OrderMap());

            //Seed Value Objects

            base.OnModelCreating(modelBuilder);
        }
    }
}
