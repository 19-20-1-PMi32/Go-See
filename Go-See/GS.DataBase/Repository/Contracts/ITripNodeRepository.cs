using GS.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.DataBase.Repository.Contracts
{
    public interface ITripNodeRepository
    {
        Task<IEnumerable<TripNode>> GetAll();

        Task<TripNode> Get(Guid id);

        void Create(TripNode entity);

        void Update(TripNode entity);

        void Delete(Guid id);

        Task CreateRange(List<TripNode> tripNodes);

        Task DeleteByTripId(Guid id);
    }
}