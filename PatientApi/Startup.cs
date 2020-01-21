using AutoMapper;
using CommunCabinet.MapperServices;
using CommunCabinet.MapperServices.Interfaces;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;

namespace PatientApi
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

            services.AddDbContext<CabinetContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CabinetConnection")).EnableSensitiveDataLogging());
            //services.AddDataAccessServices(Configuration.GetConnectionString("CabinetConnection"));
            services.AddControllers()
          .AddNewtonsoftJson(options =>
          {
              options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            //services.AddSwaggerGenNewtonsoftSupport(); // explicit opt-in

            //services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            //     .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                    });
            });
            //services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
            //{
            //    options.Authority = options.Authority + "/v2.0/";         // Microsoft identity platform
            //    options.TokenValidationParameters.ValidateIssuer = false; // accept several tenants (here simplified)
            //});

            //services.AddMvc(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                    .RequireAuthenticatedUser()
            //                    .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});

            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPatientMapperService, PatientMapperService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IParentRepository, ParentRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseBrowserLink();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Patient/Error");
                app.UseHsts();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
