using System;
using System.Collections.Generic;
using System.Text;
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

        private readonly Trip _testTrip;

        protected override string ContextDBName => "Trip Service Test";

        public TripServiceTest() : base()
        {
            _service = new TripService(_unitOfWork, _mapper);

            //var testPlaces = SeedDataProvider.GetPlaces();
            //for (int i = 0; i < 3; ++i)
            //{
            //    _unitOfWork.PlaceRepository.Create(testPlaces[i]);
            //}

            //var testTripNodes = SeedDataProvider.GetTripNodes();
            //for (int i = 0; i < 3; ++i)
            //{
            //    _unitOfWork.TripNodeRepository.Create(testTripNodes[i]);
            //}

            var testUsers = SeedDataProvider.GetUsers();
            for (int i=0; i < 3; ++i)
            {
                _unitOfWork.UserRepository.Create(testUsers[i]);
            }

            //var testTrips = SeedDataProvider.GetTrips();
            //_unitOfWork.TripRepository.Create(testTrips[0]);

            _unitOfWork.Commit().Wait();
        }

        public async override void Dispose()
        {
            //var testPlaces = await _unitOfWork.PlaceRepository.GetAll();
            //foreach (var testPlace in testPlaces)
            //{
            //    _unitOfWork.PlaceRepository.Delete(testPlace.Id);
            //}

            //var testTripNodes = await _unitOfWork.TripNodeRepository.GetAll();
            //foreach (var testTripNode in testTripNodes)
            //{
            //    _unitOfWork.TripNodeRepository.Delete(testTripNode.Id);
            //}

            var testUsers = await _unitOfWork.UserRepository.GetAllAsync();
            foreach (var testUser in testUsers)
            {
                _unitOfWork.UserRepository.Delete(testUser.Id);
            }

            //var testTrips = await _unitOfWork.TripRepository.GetAll();
            //foreach (var testTrip in testTrips)
            //{
            //    _unitOfWork.TripRepository.Delete(testTrip.Id);
            //}

            await _unitOfWork.Commit();

            base.Dispose();
        }

        [Fact]
        public void TestSomething()
        {
            Assert.True(true);
        }
    }
}
