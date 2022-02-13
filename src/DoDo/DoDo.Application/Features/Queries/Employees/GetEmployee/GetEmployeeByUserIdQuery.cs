using DoDo.Application.Models.Jobbers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Queries.Jobbers.GetJobber
{
    public class GetJobberByUserIdQuery : IRequest<JobberViewModel>
    {
        public int UserId { get; set; }
        public string Password { get; set; }

        public GetJobberByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
