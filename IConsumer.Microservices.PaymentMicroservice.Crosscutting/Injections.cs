using IConsumer.Microservices.Common.Domain.UoW;
using IConsumer.Microservices.Common.Infra.DataAccess.UoW;
using IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate;
using IConsumer.Microservices.PaymentMicroService.DataAccess.Context;
using IConsumer.Microservices.PaymentMicroService.DataAccess.Repositories;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Crosscutting
{
    public static class Injections
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            //Services
            services.AddScoped<IPaymentService, PaymentService>();
        }

        public static void AddDbContext(this IServiceCollection services)
        {
            //DBContext
            services.AddScoped<DbContext, PaymentContext>();

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
