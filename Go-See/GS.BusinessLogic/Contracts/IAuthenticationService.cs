﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Contracts
{
    public interface IAuthenticationService
    {
        Task<Guid> LogIn(string username, string password);

        Task<Guid> CreateUser(GS.Core.DTO.User userParam);
    }
}
