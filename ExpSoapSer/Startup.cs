using ExpSoapSer.Context;
using ExpSoapSer.Interfaces;
using ExpSoapSer.Models;
using ExpSoapSer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SoapCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;


namespace ExpSoapSer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSoapCore();
            services.TryAddSingleton<IAccelerationService, AccelerationService>();
            services.TryAddSingleton<IManufacturerService, ManufacturerService>();

            var connString = _configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            //app.UseEndpoints(endpoints => {
            //    endpoints.UseSoapEndpoint<AccelerationService>("/ServicePath.asmx", new SoapEncoderOptions());
            //});

            app.UseSoapEndpoint<IAccelerationService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer, false, null);
            app.UseSoapEndpoint<IManufacturerService>("/Manufacturer.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer, false, null);
        }
    }
}
