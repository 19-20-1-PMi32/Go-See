using GS.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GS.DataBaseTest
{
    public class TripNodeRepositoryTest
    {
        public TripNodeRepositoryTest() { }

        public UnitOfWork UnitOfWork { get; set; }

        public UnitOfWork GetOption(string name)
        {
            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;

            var context = new GSDbContext(options);

            UnitOfWork = new UnitOfWork(context);

            return UnitOfWork;

        }

        [Fact]
        public async Task Get()
        {

            UnitOfWork = GetOption("TestGetTripNode");

            var expectedTripNode = new DataBase.Entities.TripNode()
            {
                Id = 1,
                TripId = 1,
                PlaceId = 1,
                SequenceNumber = 1
            };

            UnitOfWork.TripNodeRepository.Create(expectedTripNode);

            UnitOfWork.Commit();

            var tripNode = await UnitOfWork.TripNodeRepository.Get(1);

            Assert.Equal(expectedTripNode.Id, tripNode.Id);

        }

        [Fact]
        public async Task Create()
        {

            UnitOfWork = GetOption("TestCreateTripNode");

            var expectedTripNode = new DataBase.Entities.TripNode()
            {
                Id = 1,
                TripId = 1,
                PlaceId = 1,
                SequenceNumber = 1
            };

            UnitOfWork.TripNodeRepository.Create(expectedTripNode);

            UnitOfWork.Commit();

            var tripNode = UnitOfWork.TripNodeRepository.Get(1);

            Assert.Equal(expectedTripNode.Id, tripNode.Id);

        }

        [Fact]
        public async Task GetAll()
        {

            UnitOfWork = GetOption("TestGetAllTripNodes");


            var tripNodes = new List<DataBase.Entities.TripNode>()
            {
                new DataBase.Entities.TripNode()
                {
                    Id = 1,
                    TripId = 1,
                    PlaceId = 1,
                    SequenceNumber = 1
                },

                new DataBase.Entities.TripNode()
                {
                    Id = 2,
                    TripId = 2,
                    PlaceId = 2,
                    SequenceNumber = 2
                }
             };

            UnitOfWork.TripNodeRepository.Create(tripNodes[0]);

            UnitOfWork.TripNodeRepository.Create(tripNodes[1]);

            UnitOfWork.Commit();

            var test = await UnitOfWork.TripNodeRepository.GetAll();

            List<DataBase.Entities.TripNode> trip = test.ToList();

            Assert.Equal(2, trip.Count());

        }

        [Fact]
        public async Task Update()
        {

            UnitOfWork = GetOption("TestUpdateTripNode");


            var expectedTripNode = new DataBase.Entities.TripNode()
            {
                Id = 1,
                TripId = 1,
                PlaceId = 1,
                SequenceNumber = 1
            };

            UnitOfWork.TripNodeRepository.Create(expectedTripNode);

            UnitOfWork.Commit();

            expectedTripNode.Id = 4;

            UnitOfWork.TripNodeRepository.Update(expectedTripNode);

            var test = UnitOfWork.TripNodeRepository.Get(1);

            Assert.Equal(expectedTripNode.Id, test.Id);

        }


        [Fact]
        public async Task Delete()
        {

            UnitOfWork = GetOption("TestDeleteTripNode");


            var tripNodes = new List<DataBase.Entities.TripNode>()
            {
                new DataBase.Entities.TripNode()
                {
                    Id = 1,
                    TripId = 1,
                    PlaceId = 1,
                    SequenceNumber = 1
                },

                new DataBase.Entities.TripNode()
                {
                    Id = 2,
                    TripId = 2,
                    PlaceId = 2,
                    SequenceNumber = 2
                }
             };

            UnitOfWork.TripNodeRepository.Create(tripNodes[0]);

            UnitOfWork.TripNodeRepository.Create(tripNodes[1]);

            UnitOfWork.TripNodeRepository.Delete(1);

            UnitOfWork.Commit();

            var test = UnitOfWork.TripNodeRepository.GetAll();

            List<DataBase.Entities.TripNode> trips = test.ToList();

            Assert.Equal(1, trips.Count());

        }

    }
}
