﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cabinet.Data;
using Cabinet.Models;
using Cabinet.Services;
using Infrastructure.Repositories;
using Core.Interfaces;
using Cabinet.Interfaces;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using Core.Services;
using Infrastructure.Configurations;
using Core.Entities.Identity;

namespace Cabinet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // Gerry
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.AddDataAccessServices(Configuration.GetConnectionString("CabinetConnection"));
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            //services.AddScoped<IPatientRepository, PatientRepository>();
            //services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IPatientViewModelService, PatientViewModelService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IConsultationViewModelService, ConsultationViewModelService>();
            services.AddScoped<IScheduleViewModelService, ScheduleViewModelService>();
            
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@31362e322e30gl9DaqAIDbQnW8qzhE5dNdp53oBRcySLZldFTkTflmM=");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA3MjRAMzEzNjJlMzIyZTMwRHFNenA4Q3M3RlJUblN5OHN5TG9hZWJQVVpPa29IM09JMW1OYnd0c04yWT0=");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Patient/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Patient}/{action=Index}/{id?}");
            });
        }
    }
}
