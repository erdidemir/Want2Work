using DoDo.Application.Contracts.Persistence.Repositories.Companies;
using DoDo.Domain.Entities.Companies;
using DoDo.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Contracts.Persistence.Repositories.Companies
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
