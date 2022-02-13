using DoDo.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Domain.Entities.Companies
{
    public class LegalCompanyType : EntityBase
    {
        public LegalCompanyType()
        {
            Companies = new HashSet<Company>();
        }
        public string Name { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
