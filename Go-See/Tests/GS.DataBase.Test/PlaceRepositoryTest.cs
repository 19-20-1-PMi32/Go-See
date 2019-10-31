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

            UnitOfWork = GetOption("TestGetPlace");


            var expectedPlace = new DataBase.Entities.Place()
            {
                Id = 1,
                Name = "Saint Sophia's Cathedral",
                CityId = 1,
                Type = "architecture",
                Description = "Saint Sophia’s Cathedral is an outstanding complex; "
            };
            
            UnitOfWork.PlaceRepository.Create(expectedPlace);

            UnitOfWork.Commit();

            var place = await UnitOfWork.PlaceRepository.Get(1);

            Assert.Equal(expectedPlace.Id, place.Id);

            Assert.Equal(expectedPlace.Name, place.Name);

            Assert.Equal(expectedPlace.CityId, place.CityId);

            Assert.Equal(expectedPlace.Type, place.Type);

            Assert.Equal(expectedPlace.Description, place.Description);

        }

        [Fact]
        public async Task Create()
        {

            UnitOfWork = GetOption("TestCreatePlace");


            var expectedPlace = new DataBase.Entities.Place()
            {
                Id = 1,
                Name = "Saint Sophia's Cathedral",
                CityId = 1,
                Type = "architecture",
                Description = "Saint Sophia’s Cathedral is an outstanding complex; "
            };

            UnitOfWork.PlaceRepository.Create(expectedPlace);

            UnitOfWork.Commit();

            var place = await UnitOfWork.PlaceRepository.Get(1);

            Assert.Equal(expectedPlace.Id, place.Id);

            Assert.Equal(expectedPlace.Name, place.Name);

            Assert.Equal(expectedPlace.CityId, place.CityId);

            Assert.Equal(expectedPlace.Type, place.Type);

            Assert.Equal(expectedPlace.Description, place.Description);

        }

        [Fact]
        public async Task GetAll()
        {

            UnitOfWork = GetOption("TestGetAllPlace");


            var places = new List<DataBase.Entities.Place>()
            {
                new DataBase.Entities.Place()
                {
                    Id = 1,
                    Name = "Saint Sophia's Cathedral",
                    CityId = 1,
                    Type = "architecture",
                    Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                },

                new DataBase.Entities.Place()
                {
                     Id = 2,
                    Name = "Saint Sophia's Cathedral",
                    CityId = 2,
                    Type = "architecture",
                    Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                }

            };


            UnitOfWork.PlaceRepository.Create(places[0]);

            UnitOfWork.PlaceRepository.Create(places[1]);

            UnitOfWork.Commit();

            var test = await UnitOfWork.PlaceRepository.GetAll();

            List<DataBase.Entities.Place> place = test.ToList();

            Assert.Equal(2, place.Count());

        }

        [Fact]
        public async Task Update()
        {

            UnitOfWork = GetOption("TestUpdatePlace");


            var expectedPlace = new DataBase.Entities.Place()
            {
                Id = 1,
                Name = "Saint Sophia's Cathedral",
                CityId = 1,
                Type = "architecture",
                Description = "Saint Sophia’s Cathedral is an outstanding complex; "
            };

            UnitOfWork.PlaceRepository.Create(expectedPlace);

            UnitOfWork.Commit();

            expectedPlace.CityId = 4;

            UnitOfWork.PlaceRepository.Update(expectedPlace);

            var test = await UnitOfWork.PlaceRepository.Get(1);

            Assert.Equal(expectedPlace.CityId, test.CityId);

        }

        [Fact]
        public async Task Delete()
        {

            UnitOfWork = GetOption("TestDeletePlace");


            var places = new List<DataBase.Entities.Place>()
            {
                new DataBase.Entities.Place()
                {
                    Id = 1,
                    Name = "Saint Sophia's Cathedral",
                    CityId = 1,
                    Type = "architecture",
                    Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                },

                new DataBase.Entities.Place()
                {
                     Id = 2,
                    Name = "Saint Sophia's Cathedral",
                    CityId = 2,
                    Type = "architecture",
                    Description = "Saint Sophia’s Cathedral is an outstanding complex; "
                }

            };

            UnitOfWork.PlaceRepository.Create(places[0]);

            UnitOfWork.PlaceRepository.Create(places[1]);

            UnitOfWork.PlaceRepository.Delete(1);

            UnitOfWork.Commit();

            var test = await UnitOfWork.PlaceRepository.GetAll();

            List<DataBase.Entities.Place> place = test.ToList();

            Assert.Equal(1, place.Count());
                   
        }
    }
}
