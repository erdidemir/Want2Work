﻿using DoDo.Domain.Entities.Authentications;
using DoDo.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Domain.Entities.Jobbers
{
    public class Jobber : EntityBase
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual User User { get; set; }
    }
}
