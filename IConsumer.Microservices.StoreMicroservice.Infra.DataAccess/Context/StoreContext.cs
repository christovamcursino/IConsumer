using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Context
{
    public class StoreContext : DbContext
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
            modelBuilder.HasDefaultSchema("Store");

            modelBuilder.Entity<Store>();
            modelBuilder.Entity<StoreTable>();

            //Map
            modelBuilder.ApplyConfiguration(new StoreMap());

            //Seed Value Objects

            base.OnModelCreating(modelBuilder);
        }
    }
}
