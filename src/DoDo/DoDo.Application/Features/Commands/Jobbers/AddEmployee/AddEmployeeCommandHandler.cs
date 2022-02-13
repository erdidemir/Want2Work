using AutoMapper;
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

namespace DoDo.Application.Features.Commands.Jobbers.AddJobber
{
    public class AddJobberCommandHandler : IRequestHandler<AddJobberCommand, int>
    {
        private readonly IJobberService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<AddJobberCommandHandler> _logger;
        public AddJobberCommandHandler(IJobberService employeeService,
            IMapper mapper,
            ILogger<AddJobberCommandHandler> logger)
        {
            _employeeService = employeeService; 
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddJobberCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Jobber>(request);

            var newJobber = _employeeService.AddAsync(employeeEntity);

            _logger.LogInformation($"Jobber {newJobber.Id} is successfully created.");

            //await SendEmail(newJobber);

            return newJobber.Id;
        }
    }
}
