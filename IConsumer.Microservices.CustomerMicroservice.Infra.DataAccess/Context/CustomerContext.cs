using IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate;
using IConsumer.Microservices.CustomerMicroservice.Infra.DataAccess.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.CustomerMicroservice.Infra.DataAccess.Context
{
    public class CustomerContext : DbContext
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
            modelBuilder.HasDefaultSchema("Customer");

            modelBuilder.Entity<Customer>();

            //Map
            modelBuilder.ApplyConfiguration(new CustomerMap());

            //Seed Value Objects

            base.OnModelCreating(modelBuilder);
        }
    }
}
