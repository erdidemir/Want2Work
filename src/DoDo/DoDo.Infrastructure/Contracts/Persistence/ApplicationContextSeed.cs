using DoDo.Domain.Entities.Authentications;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Contracts.Persistence
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationContext applicationContext, ILogger<ApplicationContextSeed> logger)
        {
            if (!applicationContext.Roles.Any())
            {
                applicationContext.Roles.AddRange(new List<Role>
                {
                    new Role{ Name="Administrator"},
                    new Role{ Name="Company"},
                    new Role{ Name="Jobber"}

                });
                await applicationContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationContext).Name);
            }
        }
    }
}
