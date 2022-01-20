using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Infrastructure.Contracts.Persistence;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Commons;
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

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));



            return services;
        }
    }
}
