using DoDo.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Domain.Entities.Settings
{
    public class Country : EntityBase
    {
        public string Name { get; set; }    
        public string TelephoneCode { get; set; } 
        public bool IsEUCountry { get; set; }
    }
}
