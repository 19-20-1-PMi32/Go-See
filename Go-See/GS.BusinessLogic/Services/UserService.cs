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
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUser(Guid userId)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
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
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }
    }
}
