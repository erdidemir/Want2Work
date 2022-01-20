using AutoMapper;
using DoDo.Application.Services.Employees;
using DoDo.Domain.Entities.Employees;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Commands.Employees.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, int>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<AddEmployeeCommandHandler> _logger;
        public AddEmployeeCommandHandler(IEmployeeService employeeService,
            IMapper mapper,
            ILogger<AddEmployeeCommandHandler> logger)
        {
            _employeeService = employeeService; 
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Employee>(request);

            var newEmployee = _employeeService.AddAsync(employeeEntity);

            _logger.LogInformation($"Employee {newEmployee.Id} is successfully created.");

            //await SendEmail(newEmployee);

            return newEmployee.Id;
        }
    }
}
