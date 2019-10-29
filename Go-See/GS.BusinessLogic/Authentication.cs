using GS.BusinessLogic.Contracts;
using GS.DataBase;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic
{
    public class Authentication : IAuthentication
    {
        private UnitOfWork unitOfWork;

        public Authentication(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Guid CreateUser(GS.Core.DTO.User userParam)
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
            unitOfWork.Commit();

            return id;
        }

        public async Task<bool> LogIn(string username, string password)
        {
            IEnumerable<GS.DataBase.Entities.User> users = await unitOfWork.UserRepository.GetAllAsync();

            GS.DataBase.Entities.User user = users.Where(entry => entry.Login == username).First();
            
            if (user.PasswordHash == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
