using DoDo.Application.Models.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Queries.Employees.GetEmployee
{
    public class GetEmployeeByUserIdQuery : IRequest<EmployeeViewModel>
    {
        public int UserId { get; set; }
        public string Password { get; set; }

        public GetEmployeeByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
