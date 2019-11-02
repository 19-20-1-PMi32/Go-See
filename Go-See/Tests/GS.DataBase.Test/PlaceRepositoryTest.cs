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
    public class PlaceRepositoryTest
    {
        public PlaceRepositoryTest() { }

        [Fact]
        public async Task Get()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetPlace"))
            {
                var expectedPlace = new DataBase.Entities.Place()
                {
                    Id = Guid.NewGuid(),
                    Name = "Saint Sophia's Cathedral",
                    CityId = Guid.NewGuid(),
                    Type = "architecture",
                    Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                };

                unitOfWork.PlaceRepository.Create(expectedPlace);

                await unitOfWork.Commit().ConfigureAwait(true);

                var place = await unitOfWork.PlaceRepository.Get(expectedPlace.Id).ConfigureAwait(true);

                Assert.Equal(expectedPlace.Id, place.Id);

                Assert.Equal(expectedPlace.Name, place.Name);

                Assert.Equal(expectedPlace.CityId, place.CityId);

                Assert.Equal(expectedPlace.Type, place.Type);

                Assert.Equal(expectedPlace.Description, place.Description);
            }
        }

        [Fact]
        public async Task Create()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestCreatePlace"))
            {

                var expectedPlace = new DataBase.Entities.Place()
                {
                    Id = Guid.NewGuid(),
                    Name = "Saint Sophia's Cathedral",
                    CityId = Guid.NewGuid(),
                    Type = "architecture",
                    Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                };

                unitOfWork.PlaceRepository.Create(expectedPlace);

                await unitOfWork.Commit().ConfigureAwait(true);

                var place = await unitOfWork.PlaceRepository.Get(expectedPlace.Id).ConfigureAwait(true);

                Assert.Equal(expectedPlace.Id, place.Id);

                Assert.Equal(expectedPlace.Name, place.Name);

                Assert.Equal(expectedPlace.CityId, place.CityId);

                Assert.Equal(expectedPlace.Type, place.Type);

                Assert.Equal(expectedPlace.Description, place.Description);
            }
        }

        [Fact]
        public async Task GetAll()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetAllPlace"))
            {
                var places = new List<DataBase.Entities.Place>()
                {
                    new DataBase.Entities.Place()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Saint Sophia's Cathedral",
                        CityId = Guid.NewGuid(),
                        Type = "architecture",
                        Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                    },
                    new DataBase.Entities.Place()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Saint Sophia's Cathedral",
                        CityId = Guid.NewGuid(),
                        Type = "architecture",
                        Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                    }

                };

                unitOfWork.PlaceRepository.Create(places[0]);

                unitOfWork.PlaceRepository.Create(places[1]);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.PlaceRepository.GetAll().ConfigureAwait(true);

                var length = test.ToList().Count;

                Assert.Equal(2, length);
            }
        }

        [Fact]
        public async Task Update()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestUpdatePlace"))
            {

                var expectedPlace = new DataBase.Entities.Place()
                {
                    Id = Guid.NewGuid(),
                    Name = "Saint Sophia's Cathedral",
                    CityId = Guid.NewGuid(),
                    Type = "architecture",
                    Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                };

                unitOfWork.PlaceRepository.Create(expectedPlace);
                await unitOfWork.Commit().ConfigureAwait(true);

                var newPlaceName = "";
                expectedPlace.Name = newPlaceName;
                unitOfWork.PlaceRepository.Update(expectedPlace);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.PlaceRepository.Get(expectedPlace.Id).ConfigureAwait(true);

                Assert.Equal(newPlaceName, test.Name);
            }
        }

        [Fact]
        public async Task Delete()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestDeletePlace"))
            {

                var places = new List<DataBase.Entities.Place>()
                {
                    new DataBase.Entities.Place()
                    {
                       Id = Guid.NewGuid(),
                       Name = "Saint Sophia's Cathedral",
                       CityId = Guid.NewGuid(),
                       Type = "architecture",
                       Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                    },
                    new DataBase.Entities.Place()
                    {
                       Id = Guid.NewGuid(),
                       Name = "Saint Sophia's Cathedral",
                       CityId = Guid.NewGuid(),
                        Type = "architecture",
                        Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                    }
                };

                unitOfWork.PlaceRepository.Create(places[0]);

                unitOfWork.PlaceRepository.Create(places[1]);

                unitOfWork.PlaceRepository.Delete(places[0].Id);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.PlaceRepository.GetAll().ConfigureAwait(true);

                List<DataBase.Entities.Place> place = test.ToList();

                Assert.Single(place);
            }
        }
    }
}
