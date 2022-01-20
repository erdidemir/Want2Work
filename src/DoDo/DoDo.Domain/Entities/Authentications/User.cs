using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoDo.Domain.Entities.Employees;
using Microsoft.AspNetCore.Identity;

namespace DoDo.Domain.Entities.Authentications
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            Employees = new HashSet<Employee>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        #region Employees
        public virtual ICollection<Employee> Employees { get; set; }

        #endregion
    }
}
