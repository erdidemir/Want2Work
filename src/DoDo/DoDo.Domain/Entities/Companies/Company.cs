﻿using DoDo.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Domain.Entities.Companies
{
    public class Company : EntityBase
    {
        public string Name { get; set; }

        public int LegalCompanyTypeId { get; set; }

        public LegalCompanyType LegalCompanyType { get; set; }

        public string WebSite { get; set; }
        
    }
}
