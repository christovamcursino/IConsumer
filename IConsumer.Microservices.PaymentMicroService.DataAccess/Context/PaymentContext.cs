using IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate;
using IConsumer.Microservices.PaymentMicroService.DataAccess.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroService.DataAccess.Context
{
    public class PaymentContext : DbContext
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
            modelBuilder.HasDefaultSchema("Payment");

            modelBuilder.Entity<Payment>();
            modelBuilder.Entity<Invoice>();

            //Map
            modelBuilder.ApplyConfiguration(new InvoiceMap());

            //Seed Value Objects

            base.OnModelCreating(modelBuilder);
        }
    }
}
