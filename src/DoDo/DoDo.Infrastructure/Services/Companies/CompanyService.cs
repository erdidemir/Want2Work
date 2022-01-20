using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Application.Services.Companies;
using DoDo.Domain.Entities.Companies;
using DoDo.Infrastructure.Services.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Services.Companies
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly IRepositoryBase<Company> _entityRepository;
        public CompanyService(IRepositoryBase<Company> entityRepository) : base(entityRepository)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));

        }
    }
}
