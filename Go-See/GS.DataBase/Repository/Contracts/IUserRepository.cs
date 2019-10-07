using System.Collections.Generic;
using System.Threading.Tasks;
using GS.DataBase.Entities;

namespace GS.DataBase.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        
        Task<User> Get(string id);
        
        void Create(User entity);
        
        void Update(User entity);
        
        void Delete(string id);
    }
}