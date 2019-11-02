using GS.DataBase.Entities;
using GS.DataBase.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.DataBase.Repository
{
    class PlaceRepository : IPlaceRepository
    {
        private readonly GSDbContext _dbContext;

        public PlaceRepository(GSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Place> Get(Guid id)
        {
            return await _dbContext.Places.FindAsync(id);
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            return await _dbContext.Places.ToListAsync();
        }

        public void Create(Place entity)
        {
            _dbContext.Places.Add(entity);
        }

        public void Update(Place entity)
        {
            _dbContext.Places.Update(entity);
        }

        public async void Delete(Guid id)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place != null)
            {
                _dbContext.Places.Remove(place);
            }
        }
    }
}
