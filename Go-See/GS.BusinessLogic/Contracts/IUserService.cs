using GS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Contracts
{
    public interface IUserService
    {
        Task<User> GetUser(Guid userId);

        Task UpdateLogin(Guid userId, string newLogin);

        Task UpdateFirstName(Guid userId, string newFirstName);

        Task UpdateLastName(Guid userId, string newLastName);

        Task UpdateEmail(Guid userId, string newEmail);

        Task UpdatePhone(Guid userId, string newPhone);

        Task UpdatePasswordHash(Guid userId, string newPasswordHash);
    }
}
