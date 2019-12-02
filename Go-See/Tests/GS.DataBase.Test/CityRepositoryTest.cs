using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GS.DataBaseTest
{
    public class CityRepositoryTest
    {
        public CityRepositoryTest() { }

        [Fact]
        public async Task Get()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetCity"))
            {
                var expectedCity = new DataBase.Entities.City()
                {
                    Id = new Guid(),
                    Name = "Lviv",
                    Description = "very beautiful city"
                };

                unitOfWork.CityRepository.Create(expectedCity);

                await unitOfWork.Commit().ConfigureAwait(true);

                var city = await unitOfWork.CityRepository.Get(expectedCity.Id).ConfigureAwait(true);

                Assert.Equal(expectedCity.Id, city.Id);

                Assert.Equal(expectedCity.Name, city.Name);

                Assert.Equal(expectedCity.Description, city.Description);
            }
        }

        [Fact]
        public async Task Create()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestCreateCity"))
            {

                var expectedCity = new DataBase.Entities.City()
                {
                    Id = Guid.NewGuid(),
                    Name = "Lviv",
                    Description = "very beautiful city"
                };

                unitOfWork.CityRepository.Create(expectedCity);

                await unitOfWork.Commit().ConfigureAwait(true);

                var city = await unitOfWork.CityRepository.Get(expectedCity.Id).ConfigureAwait(true);

                Assert.Equal(expectedCity.Id, city.Id);

                Assert.Equal(expectedCity.Name, city.Name);

                Assert.Equal(expectedCity.Description, city.Description);
            }
        }

        [Fact]
        public async Task GetAll()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetAllCity"))
            {

                var cities = new List<DataBase.Entities.City>()
                {
                    new DataBase.Entities.City()
                    {
                       Id = Guid.NewGuid(),
                        Name = "Lviv",
                        Description = "very beautiful city"
                    },
                    new DataBase.Entities.City()
                    {
                         Id = Guid.NewGuid(),
                        Name = "Budapest",
                        Description = "big industrial city "
                    }

                };

                unitOfWork.CityRepository.Create(cities[0]);

                unitOfWork.CityRepository.Create(cities[1]);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.CityRepository.GetAll().ConfigureAwait(true);

                var length = test.ToList().Count;

                Assert.Equal(2, length);
            }
        }

        [Fact]
        public async Task Update()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestUpdateCity"))
            {

                var expectedCity = new DataBase.Entities.City()
                {
                    Id = Guid.NewGuid(),
                    Name = "Lviv",
                    Description = "very beautiful city"
                };

                unitOfWork.CityRepository.Create(expectedCity);

                await unitOfWork.Commit().ConfigureAwait(true);

                var newUserId = Guid.NewGuid();
                expectedCity.Id = newUserId;

                unitOfWork.CityRepository.Update(expectedCity);

                var test = await unitOfWork.CityRepository.Get(newUserId).ConfigureAwait(true);

                Assert.Equal(expectedCity.Id, test.Id);
            }
        }

        [Fact]
        public async Task Delete()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestDeleteCity"))
            {

                var cities = new List<DataBase.Entities.City>()
                {
                    new DataBase.Entities.City()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Lviv",
                        Description = "very beautiful city"
                    },
                    new DataBase.Entities.City()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Budapest",
                        Description = "big industrial city "
                    }
                };

                unitOfWork.CityRepository.Create(cities[0]);

                unitOfWork.CityRepository.Create(cities[1]);

                await unitOfWork.CityRepository.Delete(cities[0].Id);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.CityRepository.GetAll().ConfigureAwait(true);

                var city = test.ToList();

                Assert.Single(city);
            }
        }
    }
}
