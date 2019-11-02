using GS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Contracts
{
    public interface IUserService
    {
        Task<User> GetUser(Guid id); 
    }
}
