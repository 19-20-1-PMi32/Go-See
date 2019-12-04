using AutoMapper;
using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Trip> GetById(Guid tripId)
        {
            var tripEntity = await GetTripEntity(tripId);

            var trip = _mapper.Map<Trip>(tripEntity);

            return trip;
        }

        public async Task<TripWithTripNodes> GetByIdWithTripNodes(Guid tripId)
        {
            var tripEntity = await GetTripEntity(tripId);

            var trip = _mapper.Map<TripWithTripNodes>(tripEntity);

            return trip;
        }

        public async Task<IEnumerable<TripWithTripNodes>> GetByUserIdWithTripNodes(Guid userId)
        {
            var trips = await _unitOfWork.TripRepository.GetAll();

            return _mapper.Map<IEnumerable<TripWithTripNodes>>(trips.Where(trip => trip.UserId == userId));
        }

        public async Task<IEnumerable<Trip>> GetByUserId(Guid userId)
        {
            var trips = await _unitOfWork.TripRepository.GetAll();
            return _mapper.Map<IEnumerable<Trip>>(trips.Where(trip => trip.UserId == userId));
        }

        public async Task UpdateName(Guid tripId, string newName)
        {
            var tripEntity = await GetTripEntity(tripId);

            tripEntity.Name = newName;

            _unitOfWork.TripRepository.Update(tripEntity);

            await _unitOfWork.Commit();
        }

        public async Task UpdateTripNodes(Guid tripId, List<GS.DataBase.Entities.TripNode> newTripNodes)
        {
            var tripEntity = await GetTripEntity(tripId);

            newTripNodes.Sort(
                (node1, node2) => node1.SequenceNumber.CompareTo(node2.SequenceNumber)
            );
            int expectedSequenceNumber = 1;
            foreach (var tripNode in newTripNodes)
            {
                if (tripNode.SequenceNumber != expectedSequenceNumber)
                {
                    throw new ArgumentException($"Unexpected sequence number in trip node {tripNode.Id}");
                }
                expectedSequenceNumber++;

                if (tripNode.TripId != tripId)
                {
                    throw new ArgumentException($"Unexpected trip id in trip node {tripNode.Id}");
                }
            }

            await _unitOfWork.TripNodeRepository.DeleteByTripId(tripId);
            await _unitOfWork.Commit();

            await _unitOfWork.TripNodeRepository.CreateRange(newTripNodes);
            await _unitOfWork.Commit();
        }
    }
}
