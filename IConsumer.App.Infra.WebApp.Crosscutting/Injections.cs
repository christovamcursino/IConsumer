using IConsumer.App.Application;
using IConsumer.App.Application.Interfaces;
using IConsumer.App.Domain.Interfaces.Repositories;
using IConsumer.App.Domain.Interfaces.Services;
using IConsumer.App.Domain.Services;
using IConsumer.App.Infra.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IConsumer.App.Infra.WebApp.Crosscutting
{
    public static class Injections
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Repositories
            //services.AddScoped<ICustomerRepository, CustomerMicroserviceRepository>();
            //services.AddScoped<IOrderRepository, OrderMicroserviceRepository>();
            //services.AddScoped<IProductRepository, ProductMicroserviceRepository>();
            //services.AddScoped<IProductTypeRepository, ProductTypeMicroserviceRepository>();
            //services.AddScoped<IStoreRepository, StoreMicroserviceRepository>();

            //Services
            //services.AddScoped<ICustomerService, CustomerRemoteService>();
            //services.AddScoped<ICustomerService, CustomerRemoteService>();
            //services.AddScoped<IOrderService, OrderRemoteService>();
            //services.AddScoped<IStoreService, StoreRemoteService>();

            services.AddScoped<IAppStoreService, StoreWebService>();
        }
    }
}
