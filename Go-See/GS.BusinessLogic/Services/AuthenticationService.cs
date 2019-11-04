using GS.BusinessLogic.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GS.DataBase;

namespace GS.BusinessLogic
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UnitOfWork unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork as UnitOfWork;
        }

        public async Task<Guid> CreateUser(Core.DTO.User userParam)
        {
            var isExist = (await unitOfWork.UserRepository.GetAllAsync())
                .Any(x => x.Login == userParam.Login);

            if (!isExist)
            {
                var id = Guid.NewGuid();

                var user = new GS.DataBase.Entities.User
                {
                    Id = id,
                    Login = userParam.Login,
                    FirstName = userParam.FirstName,
                    LastName = userParam.LastName,
                    Email = userParam.Email,
                    Phone = userParam.Phone,
                    PasswordHash = userParam.PasswordHash
                };

                unitOfWork.UserRepository.Create(user);
                await unitOfWork.Commit();

                return id;
            }

            throw new ArgumentException("User already exist");
        }

        public async Task<Guid> LogIn(string username, string password)
        {
            var users = await unitOfWork.UserRepository.GetAllAsync();

            var user = users.Where(entry => entry.Login == username).FirstOrDefault();

            if (user != null && user.PasswordHash == password)
            {
                return user.Id;
            }

            throw new ArgumentException("Wrong password or login");
        }
    }
}
