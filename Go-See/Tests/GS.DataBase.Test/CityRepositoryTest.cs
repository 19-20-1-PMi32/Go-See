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
    public class CityRepositoryTest
    {

        public CityRepositoryTest() { }

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

            UnitOfWork = GetOption("TestGetCity");

            var expectedCity = new DataBase.Entities.City()
            {
                Id = 1,
                Name = "Lviv",
                Description = "very beautiful city"
            };

            UnitOfWork.CityRepository.Create(expectedCity);

            UnitOfWork.Commit();

            var city = await UnitOfWork.CityRepository.Get(1);

            Assert.Equal(expectedCity.Id, city.Id);

            Assert.Equal(expectedCity.Name, city.Name);

            Assert.Equal(expectedCity.Description, city.Description);

        }

        [Fact]
        public async Task Create()
        {

            UnitOfWork = GetOption("TestCreateCity");


            var expectedCity = new DataBase.Entities.City()
            {
                Id = 1,
                Name = "Lviv",
                Description = "very beautiful city"
            };

            UnitOfWork.CityRepository.Create(expectedCity); 

            UnitOfWork.Commit();

            var city = await UnitOfWork.CityRepository.Get(1);

            Assert.Equal(expectedCity.Id, city.Id);

            Assert.Equal(expectedCity.Name, city.Name);

            Assert.Equal(expectedCity.Description, city.Description);

        }

        [Fact]
        public async Task GetAll()
        {

            UnitOfWork = GetOption("TestGetAllCity");


            var cities = new List<DataBase.Entities.City>()
            {
                new DataBase.Entities.City()
                {
                    Id = 1,
                    Name = "Lviv",
                    Description = "very beautiful city"
                },

                new DataBase.Entities.City()
                {
                     Id = 2,
                    Name = "Budapest",
                    Description = "big industrial city "
                }

            };

            UnitOfWork.CityRepository.Create(cities[0]);

            UnitOfWork.CityRepository.Create(cities[1]);

            UnitOfWork.Commit();

            var test = await UnitOfWork.CityRepository.GetAll();

            List<DataBase.Entities.City> city = test.ToList();

            Assert.Equal(2, city.Count());

        }

        [Fact]
        public async Task Update()
        {

            UnitOfWork = GetOption("TestUpdateCity");


            var expectedCity = new DataBase.Entities.City()
            {
                Id = 1,
                Name = "Lviv",
                Description = "very beautiful city"
            };

            UnitOfWork.CityRepository.Create(expectedCity);

            UnitOfWork.Commit();

            expectedCity.Id = 4;

            UnitOfWork.CityRepository.Update(expectedCity);

            var test = await UnitOfWork.CityRepository.Get(1);

            Assert.Equal(expectedCity.Id, test.Id);

        }

        [Fact]
        public async Task Delete()
        {

            UnitOfWork = GetOption("TestDeleteCity");


            var cities = new List<DataBase.Entities.City>()
            {
                new DataBase.Entities.City()
                {
                    Id = 1,
                    Name = "Lviv",
                    Description = "very beautiful city"
                },

                new DataBase.Entities.City()
                {
                    Id = 2,
                    Name = "Budapest",
                    Description = "big industrial city "
                }

            };

            UnitOfWork.CityRepository.Create(cities[0]);

            UnitOfWork.CityRepository.Create(cities[1]);

            UnitOfWork.CityRepository.Delete(1);

            UnitOfWork.Commit();

            var test = await UnitOfWork.CityRepository.GetAll();

            List<DataBase.Entities.City> city = test.ToList();

            Assert.Equal(1, city.Count());

        }

    }
}
