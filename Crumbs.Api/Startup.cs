using System;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Crumbs.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace Crumbs.Api
{
    public class Startup
    {
        private static readonly Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var baseDirectoryName = Path.GetDirectoryName(ExecutingAssembly.Location);
            
            if (String.IsNullOrWhiteSpace(baseDirectoryName))
                throw new InvalidOperationException();
            
            var loadedAssemblies = Directory
                .EnumerateFiles(baseDirectoryName, "Crumbs.*.dll", SearchOption.TopDirectoryOnly)
                .Select(Assembly.LoadFrom)
                .ToArray();

            var mvcBuilder = services.AddControllers();

            foreach (var loadedAssembly in loadedAssemblies)
            {
                mvcBuilder = mvcBuilder.AddApplicationPart(loadedAssembly);
            }
            
            mvcBuilder
                .AddControllersAsServices()
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            var serviceConfiguration = _configuration
                .GetSection(nameof(ServiceConfiguration))
                .Get<ServiceConfiguration>();
            
            services.AddDbContext<CrumbsDbContext>(o => 
            {
                o.UseNpgsql(
                        serviceConfiguration.Database.ConnectionString,
                        builder => builder.RemoteCertificateValidationCallback(UserCertificateValidationCallback)
                    )
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
            });

            services.AddMediatR(loadedAssemblies);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Crumbs.Api", Version = "v1"});
            });
        }
        
        private bool UserCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            return true;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crumbs.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}