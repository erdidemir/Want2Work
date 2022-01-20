using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Contracts.Persistence.Repositories.Companies
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
    }
}
