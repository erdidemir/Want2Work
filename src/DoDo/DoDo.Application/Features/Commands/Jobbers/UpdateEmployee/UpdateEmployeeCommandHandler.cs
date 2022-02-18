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
        private readonly IJobberService _jobberService;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateJobberCommandHandler> _logger;

        public UpdateJobberCommandHandler(IJobberService jobberService, IMapper mapper, ILogger<UpdateJobberCommandHandler> logger)
        {
            _jobberService = jobberService ?? throw new ArgumentNullException(nameof(jobberService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateJobberCommand request, CancellationToken cancellationToken)
        {
            var jobberToUpdate = await _jobberService.GetByIdAsync(request.Id);
            if (jobberToUpdate == null)
            {
                throw new NotFoundException(nameof(Jobber), request.Id);
            }

            _mapper.Map(request, jobberToUpdate, typeof(UpdateJobberCommand), typeof(Jobber));

            await _jobberService.UpdateAsync(jobberToUpdate);

            _logger.LogInformation($"Jobber {jobberToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
