using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Application.Contracts.Persistence.Repositories.Companies;
using DoDo.Application.Contracts.Persistence.Repositories.Jobbers;
using DoDo.Application.Models.Settings;
using DoDo.Application.Services.Caches;
using DoDo.Application.Services.Companies;
using DoDo.Application.Services.Jobbers;
using DoDo.Infrastructure.Contracts.Persistence;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Commons;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Companies;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Jobbers;
using DoDo.Infrastructure.Services.Caches;
using DoDo.Infrastructure.Services.Companies;
using DoDo.Infrastructure.Services.Jobbers;
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

            #region Authentications



            #endregion


            #region Commons

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            #endregion

            #region Caching

            services.AddTransient<ICacheService, MemoryCacheService>();

            #endregion

            #region Jobbers

            services.AddScoped<IJobberRepository, JobberRepository>();
            services.AddScoped<IJobberService, JobberService>();

            #endregion

            #region Companies

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();

            #endregion






            return services;
        }
    }
}
