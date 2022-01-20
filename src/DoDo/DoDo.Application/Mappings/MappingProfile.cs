using AutoMapper;
using DoDo.Application.Features.Commands.Authentications.SignUpUser;
using DoDo.Application.Features.Commands.Employees.AddEmployee;
using DoDo.Application.Features.Commands.Employees.UpdateEmployee;
using DoDo.Application.Models.Authentications;
using DoDo.Application.Models.Employees;
using DoDo.Domain.Entities.Authentications;
using DoDo.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Authentications

            CreateMap<User, SignUpUserCommand>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();

            #endregion

            #region Employees

            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Employee, AddEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            
            #endregion
        }
    }
}
