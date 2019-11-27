using GS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Contracts
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> GetAll();

        Task<Place> GetByPlaceId(Guid placeId);

        Task<IEnumerable<Place>> GetByCityId(Guid cityId);
    }
}
