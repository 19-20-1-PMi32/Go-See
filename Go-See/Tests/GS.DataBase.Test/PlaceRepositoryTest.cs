using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GS.DataBaseTest
{
    public class PlaceRepositoryTest: TestBase
    {
        public PlaceRepositoryTest() : base() { }

        [Fact]
        public async Task Get()
        {
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
        }

        [Fact]
        public async Task Create()
        {
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
        }
    }
}
