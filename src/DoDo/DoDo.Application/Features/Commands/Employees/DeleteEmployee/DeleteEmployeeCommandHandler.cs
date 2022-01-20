using AutoMapper;
using DoDo.Application.Exceptions;
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

namespace DoDo.Application.Features.Commands.Employees.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

        public DeleteEmployeeCommandHandler(IEmployeeService employeeService, IMapper mapper, ILogger<DeleteEmployeeCommandHandler> logger)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeService.GetByIdAsync(request.Id);
            if (employeeToDelete == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            await _employeeService.RemoveAsync(employeeToDelete);
            _logger.LogInformation($"Employee {employeeToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
