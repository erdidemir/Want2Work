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
        private readonly IJobberService _jobberService;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteJobberCommandHandler> _logger;

        public DeleteJobberCommandHandler(IJobberService jobberService, IMapper mapper, ILogger<DeleteJobberCommandHandler> logger)
        {
            _jobberService = jobberService ?? throw new ArgumentNullException(nameof(jobberService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteJobberCommand request, CancellationToken cancellationToken)
        {
            var jobberToDelete = await _jobberService.GetByIdAsync(request.Id);
            if (jobberToDelete == null)
            {
                throw new NotFoundException(nameof(Jobber), request.Id);
            }

            await _jobberService.RemoveAsync(jobberToDelete);
            _logger.LogInformation($"Jobber {jobberToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
