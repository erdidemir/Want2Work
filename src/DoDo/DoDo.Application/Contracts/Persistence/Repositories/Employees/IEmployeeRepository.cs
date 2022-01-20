using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Contracts.Persistence.Repositories.Employees
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
    }
}
