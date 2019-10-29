using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Contracts
{
    interface IAuthentication
    {
        Task<bool> LogIn(string username, string password);
        Guid CreateUser(GS.Core.DTO.User userParam);
    }
}
