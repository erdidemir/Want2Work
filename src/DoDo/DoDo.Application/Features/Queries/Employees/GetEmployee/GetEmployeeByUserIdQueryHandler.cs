using AutoMapper;
using DoDo.Application.Models.Employees;
using DoDo.Application.Services.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Queries.Employees.GetEmployee
{
    public class GetEmployeeByUserIdQueryHandler : IRequestHandler<GetEmployeeByUserIdQuery, EmployeeViewModel>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public GetEmployeeByUserIdQueryHandler(IEmployeeService employeeService,
                 IMapper mapper)
        {
            _employeeService = employeeService; 
            _mapper = mapper;

        }
        public async Task<EmployeeViewModel> Handle(GetEmployeeByUserIdQuery request, CancellationToken cancellationToken)
        {
            var employee = _employeeService.GetEmployeeByUserId(request.UserId).Result.FirstOrDefault();
            if (employee is null)
            {
                return null;
            }

            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
