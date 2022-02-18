using AutoMapper;
using DoDo.Application.Models.Jobbers;
using DoDo.Application.Services.Jobbers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Queries.Jobbers.GetJobber
{
    public class GetJobberByUserIdQueryHandler : IRequestHandler<GetJobberByUserIdQuery, JobberViewModel>
    {
        private readonly IJobberService _jobberService;
        private readonly IMapper _mapper;

        public GetJobberByUserIdQueryHandler(IJobberService jobberService,
                 IMapper mapper)
        {
            _jobberService = jobberService; 
            _mapper = mapper;

        }
        public async Task<JobberViewModel> Handle(GetJobberByUserIdQuery request, CancellationToken cancellationToken)
        {
            var jobber = _jobberService.GetJobberByUserId(request.UserId).Result.FirstOrDefault();
            if (jobber is null)
            {
                return null;
            }

            return _mapper.Map<JobberViewModel>(jobber);
        }
    }
}
