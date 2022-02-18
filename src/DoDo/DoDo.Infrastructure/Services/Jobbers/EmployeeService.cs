using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Application.Services.Jobbers;
using DoDo.Domain.Entities.Jobbers;
using DoDo.Infrastructure.Services.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Services.Jobbers
{
    public class JobberService : ServiceBase<Jobber>, IJobberService
    {
        private readonly IRepositoryBase<Jobber> _entityRepository;
        public JobberService(IRepositoryBase<Jobber> entityRepository) : base(entityRepository)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));

        }

        public async Task<IReadOnlyList<Jobber>> GetJobberByUserId(int userId)
        {
            return await _entityRepository.GetAsync(p=> p.User.Id == userId);
        }
    }
}
