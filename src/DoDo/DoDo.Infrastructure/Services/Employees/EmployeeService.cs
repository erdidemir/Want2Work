using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Application.Services.Employees;
using DoDo.Domain.Entities.Employees;
using DoDo.Infrastructure.Services.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Services.Employees
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        private readonly IRepositoryBase<Employee> _entityRepository;
        public EmployeeService(IRepositoryBase<Employee> entityRepository) : base(entityRepository)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));

        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByUserId(int userId)
        {
            return await _entityRepository.GetAsync(p=> p.User.Id == userId);
        }
    }
}
