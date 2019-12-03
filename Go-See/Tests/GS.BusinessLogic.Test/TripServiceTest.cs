using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.BusinessLogic.Contracts;
using GS.BusinessLogic.Services;
using GS.DataBase.Entities;
using GS.DataBase.SeedData;
using Xunit;

namespace GS.BusinessLogic.Test
{
    public class TripServiceTest : TestBase
    {
        private readonly ITripService _service;

        protected override string ContextDBName => "Trip Service Test";

        public TripServiceTest() : base()
        {
            _service = new TripService(_unitOfWork, _mapper);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        [Fact]
        public async Task GetById_Existing_Trip()
        {
            var actualTrip = await _service.GetById(_testTrip.Id);

            Assert.Equal(_testTrip.Id, actualTrip.Id);
            Assert.Equal(_testTrip.Name, actualTrip.Name);
            Assert.Equal(_testTrip.UserId, actualTrip.UserId);
        }

        [Fact]
        public async Task GetById_NotExisting_ThrowException()
        {
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.GetById(Guid.NewGuid()));
        }

        [Fact]
        public async Task GetByUserId_Existing_EnumerableOfTrips()
        {
            var expectedTrips = new List<Trip> { _testTrip };
            var actualTrips = await _service.GetByUserId(_testUser.Id);

            Assert.Equal(expectedTrips.Select(trip => trip.Id),
                         actualTrips.Select(trip => trip.Id));
        }

        [Fact]
        public async Task GetByIdWithTripNodes_Existing_TripWithTripNodes()
        {
            var expectedTrip = await _unitOfWork.TripRepository.Get(_testTrip.Id);
            var actualTrip = await _service.GetByIdWithTripNodes(_testTrip.Id);

            Assert.Equal(expectedTrip.Id, actualTrip.Id);
            Assert.Equal(expectedTrip.TripNodes.Select(tripNode => tripNode.Id),
                         actualTrip.TripNodes.Select(tripNode => tripNode.Id));
        }

        [Fact]
        public async Task GetByIdWithTripNodes_NotExisting_ThrowException()
        {
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.GetByIdWithTripNodes(Guid.NewGuid()));
        }

        [Fact]
        public async Task GetByUserIdWithTripNodes_Existing_EnumerableOfTripsWithTripNodes()
        {
            var expectedTrip = await _unitOfWork.TripRepository.Get(_testTrip.Id);
            var expectedTrips = new List<Trip> { expectedTrip };
            var actualTrips = await _service.GetByUserIdWithTripNodes(_testUser.Id);

            Assert.Equal(expectedTrips.Select(trip => trip.Id), actualTrips.Select(trip => trip.Id));
            Assert.Equal(expectedTrips.Select(trip => trip.TripNodes.Select(tripNode => tripNode.Id)),
                         actualTrips.Select(trip => trip.TripNodes.Select(tripNode => tripNode.Id)));
        }

        [Fact]
        public async Task UpdateName_Existing_UpdatedName()
        {
            string newName = "Test Name";
            await _service.UpdateName(_testTrip.Id, newName);
            var trip = await _unitOfWork.TripRepository.Get(_testTrip.Id);

            Assert.Equal(_testTrip.Id, trip.Id);
            Assert.Equal(newName, trip.Name);
        }

        [Fact]
        public async Task UpdateName_NotExisting_ThrowException()
        {
            string newName = "Test Name";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateName(Guid.NewGuid(), newName));
        }

        [Fact]
        public async Task UpdateTripNodes_Existing_UpdatedTripNodes()
        {
            var newTripNodes = new List<TripNode>();
            for (int i = 0; i < 2; ++i)
            {
                newTripNodes.Add(_testTripNodes[i]);
            }

            await _service.UpdateTripNodes(_testTrip.Id, newTripNodes);
            var trip = await _unitOfWork.TripRepository.Get(_testTrip.Id);

            Assert.Equal(_testTrip.Id, trip.Id);
            Assert.Equal(newTripNodes.Select(tripNode => tripNode.Id),
                         trip.TripNodes.Select(tripNode => tripNode.Id));
        }

        [Fact]
        public async Task UpdateTripNodes_NotExisting_ThrowException()
        {
            var newTripNodes = new List<TripNode>();
            for (int i = 0; i < 2; ++i)
            {
                newTripNodes.Add(_testTripNodes[i]);
            }

            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateTripNodes(Guid.NewGuid(), newTripNodes));
        }

        [Fact]
        public async Task UpdateTripNodes_WrongSequenceNumber_ThrowException()
        {
            var newTripNodes = new List<TripNode>();
            newTripNodes.Add(_testTripNodes[0]);
            newTripNodes.Add(_testTripNodes[1]);
            newTripNodes.Add(_testTripNodes[3]);

            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateTripNodes(_testTrip.Id, newTripNodes));
        }

        [Fact]
        public async Task UpdateTripNodes_WrongTripId_ThrowException()
        {
            var newTripNodes = new List<TripNode>
            {
                new TripNode
                {
                    Id = Guid.NewGuid(),
                    TripId = Guid.NewGuid(),
                    PlaceId = Guid.NewGuid(),
                    SequenceNumber = 1
                }
            };

            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateTripNodes(_testTrip.Id, newTripNodes));
        }
    }
}