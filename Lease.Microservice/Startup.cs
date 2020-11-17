using Delpin.Framework;
using Lease.Infrastructure.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Lease.Domain.InterFace;
using Lease.Microservice.Lease.Command;
using Lease.Microservice.Lease.Query;
using MassTransit;
using System;
using GreenPipes;
using Lease.Microservice.Consumers;

namespace Lease.Microservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<LeaseDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LeaseDatabaseConnection")));

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped<ILeaseRepository, LeaseRepository>();
            services.AddScoped<LeaseOrderQueries, LeaseOrderQueries>();

            services.AddScoped<LeaseApplicationService>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<BuyerCreateConsumer>();
                x.AddConsumer<BuyerUpdateNameConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("CustomerQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<BuyerCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("CustomerUpdateQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<BuyerUpdateNameConsumer>(provider);
                    });
                }));

            });
            services.AddMassTransitHostedService();


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Master data service",
                    Version = "v1"
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

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
