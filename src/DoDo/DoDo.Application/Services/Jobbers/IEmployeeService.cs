using DoDo.Application.Services.Commons;
using DoDo.Domain.Entities.Jobbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Services.Jobbers
{
    public interface IJobberService :  IServiceBase<Jobber>
    {
        Task<IReadOnlyList<Jobber>> GetJobberByUserId(int userId);
    }
}
