using DoDo.Application.Contracts.Persistence.Repositories.Employees;
using DoDo.Application.Services.Caches;
using DoDo.Domain.Entities.Employees;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Contracts.Persistence.Repositories.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext dbContext, ICacheService cacheService) : base(dbContext, cacheService)
        {
        }
    }
}
