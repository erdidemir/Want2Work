using DoDo.Application.Services.Commons;
using DoDo.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Services.Employees
{
    public interface IEmployeeService :  IServiceBase<Employee>
    {
        Task<IReadOnlyList<Employee>> GetEmployeeByUserId(int userId);
    }
}
