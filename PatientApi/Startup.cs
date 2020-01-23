using AutoMapper;
using CommunCabinet.MapperServices;
using CommunCabinet.MapperServices.Interfaces;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using PatientApi.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
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

            services.AddApiVersioning(
            options =>
            {
                // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                    // integrate xml comments
                    // options.IncludeXmlComments(XmlCommentsFilePath);
                });

            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API - V1", Version = "v1" });
            //    c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API - V2", Version = "v2" });
            //    c.SwaggerDoc("v3", new OpenApiInfo { Title = "My API - V3", Version = "v3" });
            //});

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
            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
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

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
