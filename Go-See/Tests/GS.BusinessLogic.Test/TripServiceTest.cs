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

        private readonly Guid _testTripId;

        private readonly Guid _testUserId;

        protected override string ContextDBName => "Trip Service Test";

        public TripServiceTest() : base()
        {
            _service = new TripService(_unitOfWork, _mapper);

            var testPlaces = SeedDataProvider.GetPlaces();
            for (int i = 0; i < 4; ++i)
            {
                _unitOfWork.PlaceRepository.Create(testPlaces[i]);
            }

            var testTripNodes = SeedDataProvider.GetTripNodes();
            for (int i = 0; i < 4; ++i)
            {
                _unitOfWork.TripNodeRepository.Create(testTripNodes[i]);
            }

            var testUsers = SeedDataProvider.GetUsers();
            _testUserId = testUsers[0].Id;
            _unitOfWork.UserRepository.Create(testUsers[0]);
            _unitOfWork.UserRepository.Create(testUsers[1]);

            var testTrips = SeedDataProvider.GetTrips();
            _testTripId = testTrips[0].Id;
            _unitOfWork.TripRepository.Create(testTrips[0]);
            _unitOfWork.TripRepository.Create(testTrips[1]);

            _unitOfWork.Commit().Wait();
        }

        public async override void Dispose()
        {
            var testPlaces = await _unitOfWork.PlaceRepository.GetAll();
            foreach (var testPlace in testPlaces)
            {
                _unitOfWork.PlaceRepository.Delete(testPlace.Id);
            }

            var testTripNodes = await _unitOfWork.TripNodeRepository.GetAll();
            foreach (var testTripNode in testTripNodes)
            {
                _unitOfWork.TripNodeRepository.Delete(testTripNode.Id);
            }

            var testUsers = await _unitOfWork.UserRepository.GetAllAsync();
            foreach (var testUser in testUsers)
            {
                _unitOfWork.UserRepository.Delete(testUser.Id);
            }

            var testTrips = await _unitOfWork.TripRepository.GetAll();
            foreach (var testTrip in testTrips)
            {
                _unitOfWork.TripRepository.Delete(testTrip.Id);
            }

            await _unitOfWork.Commit();

            base.Dispose();
        }

        [Fact]
        public async Task GetById_Existing_Trip()
        {
            var expectedTrip = await _unitOfWork.TripRepository.Get(_testTripId);
            var actualTrip = await _service.GetById(_testTripId);

            Assert.Equal(expectedTrip.Id, actualTrip.Id);
            Assert.Equal(expectedTrip.Name, actualTrip.Name);
            Assert.Equal(expectedTrip.UserId, actualTrip.UserId);
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
            var expectedTripIds = new List<Guid>{ _testTripId };
            var actualTrips = await _service.GetByUserId(_testUserId);

            Assert.Equal(expectedTripIds, actualTrips.Select(trip => trip.Id));
        }

        [Fact]
        public async Task GetByIdWithTripNodes_Existing_TripWithTripNodes()
        {
            var expectedTrip = await _unitOfWork.TripRepository.Get(_testTripId);
            var actualTrip = await _service.GetByIdWithTripNodes(_testTripId);

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
            var expectedTrip = await _unitOfWork.TripRepository.Get(_testTripId);
            var expectedTrips = new List<Trip> { expectedTrip };
            var actualTrips = await _service.GetByUserIdWithTripNodes(_testUserId);

            Assert.Equal(expectedTrips.Select(trip => trip.Id), actualTrips.Select(trip => trip.Id));
            Assert.Equal(expectedTrips.Select(trip => trip.TripNodes.Select(tripNode => tripNode.Id)),
                         actualTrips.Select(trip => trip.TripNodes.Select(tripNode => tripNode.Id)));
        }

        [Fact]
        public async Task UpdateName_Existing_UpdatedName()
        {
            string newName = "Test Name";
            await _service.UpdateName(_testTripId, newName);
            var trip = await _unitOfWork.TripRepository.Get(_testTripId);

            Assert.Equal(_testTripId, trip.Id);
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
            var seedTripNodes = SeedDataProvider.GetTripNodes();
            for (int i = 0; i < 2; ++i)
            {
                newTripNodes.Add(seedTripNodes[i]);
            }

            await _service.UpdateTripNodes(_testTripId, newTripNodes);
            var trip = await _unitOfWork.TripRepository.Get(_testTripId);

            Assert.Equal(_testTripId, trip.Id);
            Assert.Equal(newTripNodes.Select(tripNode => tripNode.Id),
                         trip.TripNodes.Select(tripNode => tripNode.Id));
        }
 
        [Fact]
        public async Task UpdateTripNodes_NotExisting_ThrowException()
        {
            var newTripNodes = new List<TripNode>();
            var seedTripNodes = SeedDataProvider.GetTripNodes();
            for (int i = 0; i < 2; ++i)
            {
                newTripNodes.Add(seedTripNodes[i]);
            }

            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateTripNodes(Guid.NewGuid(), newTripNodes));
        }
 
        [Fact]
        public async Task UpdateTripNodes_WrongSequenceNumber_ThrowException()
        {
            var newTripNodes = new List<TripNode>();
            var seedTripNodes = SeedDataProvider.GetTripNodes();
            newTripNodes.Add(seedTripNodes[0]);
            newTripNodes.Add(seedTripNodes[1]);
            newTripNodes.Add(seedTripNodes[3]);

            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateTripNodes(_testTripId, newTripNodes));
        }
 
        [Fact]
        public async Task UpdateTripNodes_WrongTripId_ThrowException()
        {
            var newTripNodes = new List<TripNode>();
            var seedTripNodes = SeedDataProvider.GetTripNodes();
            newTripNodes.Add(seedTripNodes[0]);
            newTripNodes.Add(seedTripNodes[1]);
            newTripNodes.Add(seedTripNodes[4]);

            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateTripNodes(_testTripId, newTripNodes));
        }
   }
}
