using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.DataBase.Entities;

namespace GS.DataBase.Repository.Contracts
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAll();
        
        Task<City> Get(Guid id);

        void Update(City entity);

        void Create(City entity);

        Task Delete(Guid id);
    }
}