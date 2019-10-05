using System.Collections.Generic;
using System.Threading.Tasks;
using GS.DataBase.Entities;

namespace GS.DataBase.Repository.Contracts
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> GetAll();
        
        Task<Place> Get(int id);

        void Create(Place entity);

        void Update(Place entity);

        void Delete(int id);
    }
}