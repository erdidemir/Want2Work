using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Domain.Entities.Jobs
{
    public class Job
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public string Name { get; set; }
    }
}
