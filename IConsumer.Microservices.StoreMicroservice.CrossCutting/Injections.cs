using IConsumer.Microservices.Common.Domain.UoW;
using IConsumer.Microservices.Common.Infra.DataAccess.UoW;
using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Context;
using IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.CrossCutting
{
    public static class Injections
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreTableRepository, StoreTableRepository>();

            //Services
            services.AddScoped<IStoreService, StoreService>();
        }

        public static void AddDbContext(this IServiceCollection services)
        {
            //DBContext
            services.AddScoped<DbContext, StoreContext>();

            //IoW
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
