using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoDo.Domain.Entities.Jobbers;
using Microsoft.AspNetCore.Identity;

namespace DoDo.Domain.Entities.Authentications
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            //Jobbers = new HashSet<Jobber>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        //#region Jobbers
        //public virtual ICollection<Jobber> Jobbers { get; set; }

        //#endregion
    }
}
