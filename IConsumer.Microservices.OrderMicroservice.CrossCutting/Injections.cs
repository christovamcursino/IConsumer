using IConsumer.Microservices.Common.Domain.Services;
using IConsumer.Microservices.Common.Domain.UoW;
using IConsumer.Microservices.Common.Infra.DataAccess.UoW;
using IConsumer.Microservices.Common.Infra.Helper;
using IConsumer.Microservices.Common.Infra.Messaging.Services;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.PaymentAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.StoreAggregate;
using IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Context;
using IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Repositories;
using IConsumer.MicroServices.Common.Application.Interfaces.CQRS.Messaging;
using IConsumer.MicroServices.OrderMicroservice.Application.Services;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.CrossCutting
{
    public static class Injections
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderTrackingRepository, OrderTrackingRepository>();
            services.AddScoped<IPaymentRepository, PaymentRemoteRepository>();

            //Services
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IProductQueryService, ProductQueryService>();
            services.AddScoped<IStoreTableQueryService, StoreTableQueryService>();
            services.AddScoped<IPaymentService, PaymentService>();
            
            //Commands
            services.AddScoped<IApiApplicationService, ApiApplicationService>();
            services.AddScoped<IMediatorHandler, AzureServiceBusQueue>();

            //Queryes
            services.AddScoped<IProductQueryRepository, ProductMicroserviceQueryRepository>();
            services.AddScoped<IStoreTableQueryRepository, StoreTableMicroserviceQueryRepository>();
        }

        public static void AddDbContext(this IServiceCollection services)
        {
            //DBContext
            services.AddScoped<DbContext, OrderContext>();

            //IoW
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISerializerService, SerializerService>();
        }

        public static void AddIdentityAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Properties.Resources.AuthorityServer;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "OrderMicroservice_ApiResource";
                });
        }
    }
}
