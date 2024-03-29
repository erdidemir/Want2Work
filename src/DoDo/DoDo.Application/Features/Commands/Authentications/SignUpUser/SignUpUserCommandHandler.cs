﻿using AutoMapper;
using DoDo.Domain.Entities.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Commands.Authentications.SignUpUser
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, int>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        public SignUpUserCommandHandler(
                 IMapper mapper,
                 UserManager<User> userManager,
                 RoleManager<Role> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task<int> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request);

            userEntity.UserName = userEntity.Email;
            var userCreateResult = await _userManager.CreateAsync(userEntity, request.Password);

            if (userCreateResult.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);

                return user.Id;
            }

            return 0;
        }
    }
}
