using AutoMapper;
using Cabinet.Data;
using Cabinet.Interfaces;
using Cabinet.Services;
//using Infrastructure.Configurations;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;

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
            services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<CabinetContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CabinetConnection")).EnableSensitiveDataLogging());

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.Configure<IISOptions>(options =>
            //{
            //    options.AutomaticAuthentication = false;
            //});

            services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.ContractResolver = new DefaultContractResolver();
               });
            services.AddRazorPages();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IPatientViewModelService, PatientViewModelService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IConsultationViewModelService, ConsultationViewModelService>();
            services.AddTransient<IScheduleViewModelService, ScheduleViewModelService>();
            services.AddTransient<IParentRepository, ParentRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@31362e322e30gl9DaqAIDbQnW8qzhE5dNdp53oBRcySLZldFTkTflmM=");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA3MjRAMzEzNjJlMzIyZTMwRHFNenA4Q3M3RlJUblN5OHN5TG9hZWJQVVpPa29IM09JMW1OYnd0c04yWT0=");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Patient/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
                endpoints.MapRazorPages();
            });

        }
    }
}
