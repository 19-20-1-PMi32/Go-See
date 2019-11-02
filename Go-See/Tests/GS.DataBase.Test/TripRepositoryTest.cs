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
    public class TripRepositoryTest
    {
        public TripRepositoryTest() { }

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
        public async Task Create()
        {

            UnitOfWork = GetOption("TestCreateTrip");

            var expectedTrip = new DataBase.Entities.Trip()
            {
                Id = 1,
                Name = "Rome 2019",
                UserId = Guid.NewGuid()
            };

            UnitOfWork.TripRepository.Create(expectedTrip);

            UnitOfWork.Commit();

            var trip = UnitOfWork.TripRepository.Get(1);

            Assert.Equal(expectedTrip.Id, trip.Id);

        }


        [Fact]
        public async Task Delete()
        {

            UnitOfWork = GetOption("TestDeleteTrip");


            var trips = new List<DataBase.Entities.Trip>()
            {
                new DataBase.Entities.Trip()
                {
                    Id = 1,
                    Name = "Rome 2019",
                    UserId = Guid.NewGuid()
                },

                new DataBase.Entities.Trip()
                {
                    Id = 2,
                    Name = "To the edge of the world",
                    UserId = Guid.NewGuid()
                }
            };

            UnitOfWork.TripRepository.Create(trips[0]);

            UnitOfWork.TripRepository.Create(trips[1]);

            UnitOfWork.TripRepository.DeleteAsync(1);

            UnitOfWork.Commit();

            var test = UnitOfWork.TripRepository.GetAll();

            List<DataBase.Entities.Trip> trip = test.ToList();

            Assert.Equal(1, trip.Count());

        }


        [Fact]
        public async Task Get()
        {

            UnitOfWork = GetOption("TestGetTrip");

            var expectedTrip = new DataBase.Entities.Trip()
            {
                Id = 1,
                Name = "Rome 2019",
                UserId = Guid.NewGuid()
            };

            UnitOfWork.TripRepository.Create(expectedTrip);

            UnitOfWork.Commit();

            var trip = await UnitOfWork.TripRepository.Get(1);

            Assert.Equal(expectedTrip.Id, trip.Id);

        }


        [Fact]
        public async Task GetAll()
        {

            UnitOfWork = GetOption("TestGetAllTrip");


            var trip = new List<DataBase.Entities.Trip>()
            {
                new DataBase.Entities.Trip()
                {
                    Id = 1,
                    Name = "Rome 2019",
                    UserId = Guid.NewGuid()
                },

                new DataBase.Entities.Trip()
                {
                    Id = 2,
                    Name = "To the edge of the world",
                    UserId = Guid.NewGuid()
                }
             };

            UnitOfWork.TripRepository.Create(trip[0]);

            UnitOfWork.TripRepository.Create(trip[1]);

            UnitOfWork.Commit();

            var test = await UnitOfWork.TripRepository.GetAll();

            List<DataBase.Entities.Trip> trips = test.ToList();

            Assert.Equal(2, trips.Count());

        }


        [Fact]
        public async Task Update()
        {

            UnitOfWork = GetOption("TestUpdateTrip");


            var expectedTrip = new DataBase.Entities.Trip()
            {
                Id = 1,
                Name = "Rome 2019",
                UserId = Guid.NewGuid()
            };

            UnitOfWork.TripRepository.Create(expectedTrip);

            UnitOfWork.Commit();

            expectedTrip.Id = 4;

            UnitOfWork.TripRepository.Update(expectedTrip);

            var test = UnitOfWork.TripRepository.Get(1);

            Assert.Equal(expectedTrip.Id, test.Id);

        }
    }
}
