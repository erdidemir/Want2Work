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
        private readonly IJobberService _employeeService;
        private readonly IMapper _mapper;

        public GetJobberByUserIdQueryHandler(IJobberService employeeService,
                 IMapper mapper)
        {
            _employeeService = employeeService; 
            _mapper = mapper;

        }
        public async Task<JobberViewModel> Handle(GetJobberByUserIdQuery request, CancellationToken cancellationToken)
        {
            var employee = _employeeService.GetJobberByUserId(request.UserId).Result.FirstOrDefault();
            if (employee is null)
            {
                return null;
            }

            return _mapper.Map<JobberViewModel>(employee);
        }
    }
}
