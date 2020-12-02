using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delpin.Framework;
using EventStore.ClientAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Resource.Infrastructure;
using Resource.Microservice.Projections;
using Delpin.Shared.ResourceModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Resource.Application;


namespace Resource.Microservice
{

    public class Startup
    {
        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var esConnection = EventStoreConnection.Create(
                Configuration["eventStore:connectionString"],
                ConnectionSettings.Create().KeepReconnecting(),
                Environment.ApplicationName);
            var store = new EsAggregateStore(esConnection);

            services.AddSingleton(esConnection);
            services.AddSingleton<IAggregateStore>(store);

            services.AddSingleton( new ResourceApplicationService(store));

            var resourceDetails = new List<ReadModels.ResourceDetails>();
            services.AddSingleton<IEnumerable<ReadModels.ResourceDetails>>(resourceDetails);

            var projectionManager = new ProjectionManager(esConnection,
                new ResourceDetailsProjection(resourceDetails),                
                new ResourceUpcasters(esConnection));

            services.AddSingleton<IHostedService>(
                new EventStoreService(esConnection, projectionManager));


            services.AddMvc();

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
