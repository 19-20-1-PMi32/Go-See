using AutoMapper;
using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Services
{
    public class TripService : ITripService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private async Task<GS.DataBase.Entities.Trip> GetTripEntity(Guid tripId)
        {
            var tripEntity = await _unitOfWork.TripRepository.Get(tripId);

            if (tripEntity != null)
            {
                return tripEntity;
            }
            else
            {
                throw new ArgumentException("Can not find trip with such id");
            }
        }

        public TripService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Trip> GetTrip(Guid tripId)
        {
            var tripEntity = await GetTripEntity(tripId);

            var trip = _mapper.Map<Trip>(tripEntity);

            return trip;
        }

        public async Task UpdateName(Guid tripId, string newName)
        {
            var tripEntity = await GetTripEntity(tripId);

            tripEntity.Name = newName;

            _unitOfWork.TripRepository.Update(tripEntity);

            await _unitOfWork.Commit();
        }
    }
}
