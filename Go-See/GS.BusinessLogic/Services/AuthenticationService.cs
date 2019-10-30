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
        private UnitOfWork unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork as UnitOfWork;
        }

        public async Task<Guid> CreateUser(GS.Core.DTO.User userParam)
        {
            Guid id = Guid.NewGuid();

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

        public async Task<Guid> LogIn(string username, string password)
        {
            IEnumerable<GS.DataBase.Entities.User> users = await unitOfWork.UserRepository.GetAllAsync();

            GS.DataBase.Entities.User user = users.Where(entry => entry.Login == username).First();

            if (user.PasswordHash == password)
            {
                return user.Id;
            }
            else
            {
                throw new Exception("Wrong password or login");
            }
        }
    }
}
