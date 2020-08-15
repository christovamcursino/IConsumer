﻿using IConsumer.Microservices.Common.Domain.UoW;
using IConsumer.Microservices.Common.Infra.DataAccess.UoW;
using IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate;
using IConsumer.Microservices.CustomerMicroservice.Infra.DataAccess.Context;
using IConsumer.Microservices.CustomerMicroservice.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.CustomerMicroservice.CrossCutting
{
    public static class Injections
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            //Services
            services.AddScoped<ICustomerService, CustomerService>();
        }

        public static void AddDbContext(this IServiceCollection services)
        {
            //DBContext
            services.AddScoped<DbContext, CustomerContext>();

            //IoW
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}