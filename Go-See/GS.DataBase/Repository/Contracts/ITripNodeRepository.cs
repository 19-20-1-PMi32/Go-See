using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.DataBase.Entities;

namespace GS.DataBase.Repository.Contracts
{
    public interface ITripNodeRepository
    {
        Task<IEnumerable<TripNode>> GetAll();
        
        Task<TripNode> Get(Guid id);
        
        void Create(TripNode entity);
        
        void Update(TripNode entity);
        
        void Delete(Guid id);
    }
}