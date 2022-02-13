using DoDo.Infrastructure.Queries.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Queries.Companies
{
    public class CompanyQuery : PageQuery
    {
        public string Name { get; set; }
    }
}
