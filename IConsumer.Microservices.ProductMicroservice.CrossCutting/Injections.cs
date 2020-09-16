using IConsumer.Microservices.Common.Domain.UoW;
using IConsumer.Microservices.Common.Infra.DataAccess.UoW;
using IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate;
using IConsumer.Microservices.ProductMicroservice.Infra.DataAccess.Context;
using IConsumer.Microservices.ProductMicroservice.Infra.DataAccess.Repositories;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProductMicroservice.CrossCutting
{
    public static class Injections
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
        }

        public static void AddDbContext(this IServiceCollection services)
        {
            //DBContext
            services.AddScoped<DbContext, ProductContext>();

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
                    options.ApiName = "ProductMicroservice_ApiResource";
                });
        }
    }
}
