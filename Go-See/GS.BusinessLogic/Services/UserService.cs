using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic
{
    public class UserService : IUserService
    {
        private UnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork as UnitOfWork;
        }

        public async Task<User> GetUser(Guid userId)
        {
            var userEntity = await unitOfWork.UserRepository.Get(userId);

            var user = new User
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email,
                Phone = userEntity.Phone,
                Login = userEntity.Login,
                PasswordHash = userEntity.PasswordHash
            };

            return user;
        }
    }
}
