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

namespace DoDo.Application.Features.Commands.Jobbers.UpdateJobber
{
    public class UpdateJobberCommandHandler : IRequestHandler<UpdateJobberCommand>
    {
        private readonly IJobberService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateJobberCommandHandler> _logger;

        public UpdateJobberCommandHandler(IJobberService employeeService, IMapper mapper, ILogger<UpdateJobberCommandHandler> logger)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateJobberCommand request, CancellationToken cancellationToken)
        {
            var employeeToUpdate = await _employeeService.GetByIdAsync(request.Id);
            if (employeeToUpdate == null)
            {
                throw new NotFoundException(nameof(Jobber), request.Id);
            }

            _mapper.Map(request, employeeToUpdate, typeof(UpdateJobberCommand), typeof(Jobber));

            await _employeeService.UpdateAsync(employeeToUpdate);

            _logger.LogInformation($"Jobber {employeeToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
