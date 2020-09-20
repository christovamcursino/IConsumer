using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IConsumer.App.Infra.WebApp.Crosscutting;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IConsumer.App.Ui.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "cookie";
                options.DefaultChallengeScheme = "oidc";
            }).AddCookie("cookie")
                 .AddOpenIdConnect("oidc", options =>
                 {
                     options.Authority = "https://iconsumer-ccursino-iam-microservice-identity.azurewebsites.net";
                     options.ClientId = "IConsumerDesktopApp_ClientId";
                     options.SignInScheme = "cookie";
                     options.RequireHttpsMetadata = false;
                     options.ResponseType = "code id_token token";

                     options.SaveTokens = true;
                     options.GetClaimsFromUserInfoEndpoint = true;
                     options.TokenValidationParameters.ValidateAudience = true;

                     options.Scope.Add("email");
                     options.Scope.Add("offline_access");
                     options.ClaimActions.MapJsonKey("website", "website");
                 });
            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
