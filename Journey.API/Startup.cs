using Journey.API.Infrastructure;
using Journey.API.Infrastructure.Middleware;
using Journey.Application.Account;
using Journey.Domain.Model.Customer;
using Journey.Infrastructure.Common;
using Journey.Infrastructure.SMS;
using Journey.Infrastructure.SMS.Twilo;
using Journey.SQLServerDataAccess;
using Journey.SQLServerDataAccess.ConnectionCore;
using Journey.SQLServerDataAccess.Customers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Journey.API
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
            services.AddControllers();
            services.AddScoped<IAccountService, AccountService>();
            services.Configure<ConnectionConfig>(Configuration);
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ISMSService, TwilioSMSService>();
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<ISharedUtilities, SharedUtilities>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
