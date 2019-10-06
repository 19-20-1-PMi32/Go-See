using System.Collections.Generic;
using System.Threading.Tasks;
using GS.DataBase.Entities;

namespace GS.DataBase.Repository.Contracts
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetAll();
        
        Task<Trip> Get(int id);
        
        void Create(Trip entity);
        
        void Update(Trip entity);
        
        void DeleteAsync(int id);
    }
}