using AutoMapper;
using DoDo.Application.Exceptions;
using DoDo.Application.Services.Jobbers;
using DoDo.Domain.Entities.Jobbers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Commands.Jobbers.DeleteJobber
{
    public class DeleteJobberCommandHandler : IRequestHandler<DeleteJobberCommand>
    {
        private readonly IJobberService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteJobberCommandHandler> _logger;

        public DeleteJobberCommandHandler(IJobberService employeeService, IMapper mapper, ILogger<DeleteJobberCommandHandler> logger)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteJobberCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeService.GetByIdAsync(request.Id);
            if (employeeToDelete == null)
            {
                throw new NotFoundException(nameof(Jobber), request.Id);
            }

            await _employeeService.RemoveAsync(employeeToDelete);
            _logger.LogInformation($"Jobber {employeeToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
