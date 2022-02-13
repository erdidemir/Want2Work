using AutoMapper;
using DoDo.Application.Features.Commands.Authentications.SignUpUser;
using DoDo.Application.Features.Commands.Jobbers.AddJobber;
using DoDo.Application.Features.Commands.Jobbers.UpdateJobber;
using DoDo.Application.Models.Authentications;
using DoDo.Application.Models.Companies;
using DoDo.Application.Models.Jobbers;
using DoDo.Domain.Entities.Authentications;
using DoDo.Domain.Entities.Companies;
using DoDo.Domain.Entities.Jobbers;
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

            #region Jobbers

            CreateMap<Jobber, JobberViewModel>().ReverseMap();
            CreateMap<Jobber, AddJobberCommand>().ReverseMap();
            CreateMap<Jobber, UpdateJobberCommand>().ReverseMap();

            #endregion

            #region Companies

            CreateMap<Company, CompanyViewModel>().ReverseMap();

            #endregion
        }
    }
}
