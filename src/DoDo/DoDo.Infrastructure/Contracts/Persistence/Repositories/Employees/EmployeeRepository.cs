using DoDo.Application.Contracts.Persistence.Repositories.Jobbers;
using DoDo.Application.Services.Caches;
using DoDo.Domain.Entities.Jobbers;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Contracts.Persistence.Repositories.Jobbers
{
    public class JobberRepository : RepositoryBase<Jobber>, IJobberRepository
    {
        public JobberRepository(ApplicationContext dbContext, ICacheService cacheService) : base(dbContext, cacheService)
        {
        }
    }
}
