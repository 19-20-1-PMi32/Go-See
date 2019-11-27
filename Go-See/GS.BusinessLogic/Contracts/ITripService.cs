using GS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Contracts
{
    public interface ITripService
    {
        Task<Trip> GetTrip(Guid tripId);
    }
}
