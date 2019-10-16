using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Core.Entities.Identity;
using Infrastructure.Data;

namespace Infrastructure.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddDbContext<CabinetContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
     
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
        }
    }
}
