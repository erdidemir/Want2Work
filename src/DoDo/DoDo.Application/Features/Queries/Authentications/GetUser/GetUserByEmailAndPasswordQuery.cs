﻿using DoDo.Application.Models.Authentications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Queries.Authentications.GetUser
{
    public class GetUserByEmailAndPasswordQuery : IRequest<UserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public GetUserByEmailAndPasswordQuery(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));

        }
    }
}
