using IConsumer.Microservices.Common.Domain.UoW;
using IConsumer.Microservices.Common.Infra.DataAccess.UoW;
using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Context;
using IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;

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

        public static void AddIdentityAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Properties.Resources.AuthorityServer;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "StoreMicroservice_ApiResource";
                });
        }
    }
}
