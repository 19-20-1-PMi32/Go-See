using GS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Contracts
{
    public interface ITripService
    {
        Task<Trip> GetById(Guid tripId);

        Task<TripWithTripNodes> GetByIdWithTripNodes(Guid tripId);

        Task<IEnumerable<Trip>> GetByUserId(Guid userId);

        Task<IEnumerable<TripWithTripNodes>> GetByUserIdWithTripNodes(Guid userId);

        Task UpdateName(Guid tripId, string newName);

        Task UpdateTripNodes(Guid tripId, List<GS.DataBase.Entities.TripNode> newTripNodes);
    }
}
