using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using AutoWrapper;
using MarketingBox.ExternalReferenceProxy.Api.Modules;
using MarketingBox.Sdk.Common.Models.RestApi;
using MyJetWallet.Sdk.GrpcSchema;
using MyJetWallet.Sdk.Service;
using Prometheus;
using SimpleTrading.ServiceStatusReporterConnector;

namespace MarketingBox.ExternalReferenceProxy.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.BindCodeFirstGrpc();

            services.AddHostedService<ApplicationLifetimeManager>();
            
            services.AddControllers();
            services.AddSwaggerDocument(o =>
            {
                o.Title = "ExternalReferenceProxy API";
                o.GenerateEnumMappingDescription = true;
            });

            services.AddMyTelemetry("SP-", Program.Settings.ZipkinUrl);
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseApiResponseAndExceptionWrapper<ApiResponseMap>(
                new AutoWrapperOptions
                {
                    UseCustomSchema = true,
                    IgnoreWrapForOkRequests = true
                });
            
            app.UseMetricServer();

            app.BindServicesTree(Assembly.GetExecutingAssembly());

            app.BindIsAlive();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcSchemaRegistry();
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
            
            app.UseOpenApi(settings =>
            {
                settings.Path = $"/swagger/api/swagger.json";
            });

            app.UseSwaggerUi3(settings =>
            {
                settings.EnableTryItOut = true;
                settings.Path = $"/swagger/api";
                settings.DocumentPath = $"/swagger/api/swagger.json";
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<SettingsModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
