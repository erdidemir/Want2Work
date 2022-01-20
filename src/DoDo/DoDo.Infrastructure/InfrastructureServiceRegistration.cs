using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Application.Contracts.Persistence.Repositories.Companies;
using DoDo.Application.Contracts.Persistence.Repositories.Employees;
using DoDo.Application.Enums.Caches;
using DoDo.Application.Services.Caches;
using DoDo.Application.Services.Companies;
using DoDo.Application.Services.Employees;
using DoDo.Infrastructure.Contracts.Persistence;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Commons;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Companies;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Employees;
using DoDo.Infrastructure.Services.Caches;
using DoDo.Infrastructure.Services.Companies;
using DoDo.Infrastructure.Services.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
                                             options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            #region Commons

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            #endregion

            #region Caching

            services.AddTransient<MemoryCacheService>();
            //services.AddTransient<RedisCacheService>();
            services.AddTransient<Func<CacheTech, ICacheService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case CacheTech.Memory:
                        return serviceProvider.GetService<MemoryCacheService>();
                    //case CacheTech.Redis:
                    //    return serviceProvider.GetService<RedisCacheService>();
                    default:
                        return serviceProvider.GetService<MemoryCacheService>();
                }
            });

            #endregion

            #region Employees

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            #endregion

            #region Companies

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();

            #endregion




            return services;
        }
    }
}
