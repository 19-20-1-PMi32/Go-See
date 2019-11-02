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

        [Fact]
        public async Task Create()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestCreateTrip"))
            {
                var expectedTrip = new DataBase.Entities.Trip()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rome 2019",
                    UserId = Guid.NewGuid()
                };

                unitOfWork.TripRepository.Create(expectedTrip);

                await unitOfWork.Commit().ConfigureAwait(false);

                var trip = await unitOfWork.TripRepository.Get(expectedTrip.Id).ConfigureAwait(true);

                Assert.Equal(expectedTrip.Id, trip.Id);
            }
        }


        [Fact]
        public async Task Delete()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestDeleteTrip"))
            {
                var trips = new List<DataBase.Entities.Trip>()
                {
                new DataBase.Entities.Trip()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rome 2019",
                        UserId = Guid.NewGuid()
                    },
                new DataBase.Entities.Trip()
                    {
                        Id = Guid.NewGuid(),
                        Name = "To the edge of the world",
                        UserId = Guid.NewGuid()
                    }
                };

                unitOfWork.TripRepository.Create(trips[0]);

                unitOfWork.TripRepository.Create(trips[1]);

                unitOfWork.TripRepository.Delete(trips[0].Id);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.TripRepository.GetAll().ConfigureAwait(true);

                List<DataBase.Entities.Trip> trip = test.ToList();

                Assert.Single(trip);
            }
        }


        [Fact]
        public async Task Get()
        {

            using (var unitOfWork = Utils.GetUnitOfWork("TestGetTrip"))
            {

                var expectedTrip = new DataBase.Entities.Trip()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rome 2019",
                    UserId = Guid.NewGuid()
                };

                unitOfWork.TripRepository.Create(expectedTrip);

                await unitOfWork.Commit().ConfigureAwait(true);

                var trip = await unitOfWork.TripRepository.Get(expectedTrip.Id).ConfigureAwait(true);

                Assert.Equal(expectedTrip.Id, trip.Id);
            }
        }


        [Fact]
        public async Task GetAll()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetAllTrip"))
            {
                var trip = new List<DataBase.Entities.Trip>()
                {
                    new DataBase.Entities.Trip()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rome 2019",
                        UserId = Guid.NewGuid()
                    },
                    new DataBase.Entities.Trip()
                    {
                        Id = Guid.NewGuid(),
                        Name = "To the edge of the world",
                        UserId = Guid.NewGuid()
                    }
                };

                unitOfWork.TripRepository.Create(trip[0]);

                unitOfWork.TripRepository.Create(trip[1]);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.TripRepository.GetAll().ConfigureAwait(true);

                var length = test.ToList().Count;

                Assert.Equal(2, length);
            }
        }


        [Fact]
        public async Task Update()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestUpdateTrip"))
            {
                var expectedTrip = new DataBase.Entities.Trip()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rome 2019",
                    UserId = Guid.NewGuid()
                };

                unitOfWork.TripRepository.Create(expectedTrip);
                await unitOfWork.Commit().ConfigureAwait(true);

                var newTripName = "Rome";
                expectedTrip.Name = newTripName;

                unitOfWork.TripRepository.Update(expectedTrip);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.TripRepository.Get(expectedTrip.Id).ConfigureAwait(true);

                Assert.Equal(expectedTrip.Id.ToString(), test.Id.ToString());
            }
        }
    }
}
