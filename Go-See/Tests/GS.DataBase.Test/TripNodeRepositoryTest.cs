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

        [Fact]
        public async Task Get()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetTripNode"))
            {
                var expectedTripNode = new DataBase.Entities.TripNode()
                {
                    Id = Guid.NewGuid(),
                    TripId = Guid.NewGuid(),
                    PlaceId = Guid.NewGuid(),
                    SequenceNumber = 1
                };

                unitOfWork.TripNodeRepository.Create(expectedTripNode);

                await unitOfWork.Commit().ConfigureAwait(true);

                var tripNode = await unitOfWork.TripNodeRepository.Get(expectedTripNode.Id).ConfigureAwait(true);

                Assert.Equal(expectedTripNode.Id, tripNode.Id);
            }
        }

        [Fact]
        public async Task Create()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestCreateTripNode"))
            {
                var expectedTripNode = new DataBase.Entities.TripNode()
                {
                    Id = Guid.NewGuid(),
                    TripId = Guid.NewGuid(),
                    PlaceId = Guid.NewGuid(),
                    SequenceNumber = 1
                };

                unitOfWork.TripNodeRepository.Create(expectedTripNode);

                await unitOfWork.Commit().ConfigureAwait(true);

                var tripNode = await unitOfWork.TripNodeRepository.Get(expectedTripNode.Id).ConfigureAwait(true);

                Assert.Equal(expectedTripNode.Id, tripNode.Id);
            }
        }

        [Fact]
        public async Task GetAll()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetAllTripNodes"))
            {

                var tripNodes = new List<DataBase.Entities.TripNode>()
                {
                    new DataBase.Entities.TripNode()
                    {
                        Id = Guid.NewGuid(),
                        TripId = Guid.NewGuid(),
                        PlaceId = Guid.NewGuid(),
                        SequenceNumber = 1
                    },
                    new DataBase.Entities.TripNode()
                    {
                        Id = Guid.NewGuid(),
                        TripId = Guid.NewGuid(),
                        PlaceId = Guid.NewGuid(),
                        SequenceNumber = 2
                    }
                };

                unitOfWork.TripNodeRepository.Create(tripNodes[0]);

                unitOfWork.TripNodeRepository.Create(tripNodes[1]);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.TripNodeRepository.GetAll().ConfigureAwait(true);

                var length = test.ToList().Count;

                Assert.Equal(2, length);
            }
        }

        [Fact]
        public async Task Update()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestUpdateTripNode"))
            {
                var expectedTripNode = new DataBase.Entities.TripNode()
                {
                    Id = Guid.NewGuid(),
                    TripId = Guid.NewGuid(),
                    PlaceId = Guid.NewGuid(),
                    SequenceNumber = 1
                };

                unitOfWork.TripNodeRepository.Create(expectedTripNode);
                await unitOfWork.Commit().ConfigureAwait(true);

                var newSequenceNumber = 2;
                expectedTripNode.SequenceNumber = newSequenceNumber;
                unitOfWork.TripNodeRepository.Update(expectedTripNode);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.TripNodeRepository.Get(expectedTripNode.Id).ConfigureAwait(true);

                Assert.Equal(expectedTripNode.Id.ToString(), test.Id.ToString());
            }
        }


        [Fact]
        public async Task Delete()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestDeleteTripNode"))
            {
                var tripNodes = new List<DataBase.Entities.TripNode>()
                {
                    new DataBase.Entities.TripNode()
                    {
                        Id = Guid.NewGuid(),
                        TripId = Guid.NewGuid(),
                        PlaceId = Guid.NewGuid(),
                        SequenceNumber = 1
                    },
                    new DataBase.Entities.TripNode()
                    {
                        Id = Guid.NewGuid(),
                        TripId = Guid.NewGuid(),
                        PlaceId = Guid.NewGuid(),
                        SequenceNumber = 2
                    }
                };

                unitOfWork.TripNodeRepository.Create(tripNodes[0]);

                unitOfWork.TripNodeRepository.Create(tripNodes[1]);

                unitOfWork.TripNodeRepository.Delete(tripNodes[0].Id);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.TripNodeRepository.GetAll().ConfigureAwait(true);

                var trips = test.ToList();

                Assert.Single(trips);
            }
        }

    }
}
