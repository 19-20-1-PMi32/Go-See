using GS.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.DataBase.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> Get(Guid id);

        void Create(User entity);

        void Update(User entity);

        void Delete(Guid id);
    }
}