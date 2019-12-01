using GS.DataBase.Entities;
using GS.DataBase.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.DataBase.Repository
{
    class TripRepository : ITripRepository
    {
        private readonly GSDbContext _dbContext;

        public TripRepository(GSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Trip entity)
        {
            _dbContext.Trips.Add(entity);
        }

        public async void Delete(Guid id)
        {
            var trip = await _dbContext.Trips.FindAsync(id);
            if (trip != null)
            {
                _dbContext.Trips.Remove(trip);
            }
        }

        public async Task<Trip> Get(Guid id)
        {
            return await _dbContext.Trips.FindAsync(id);
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _dbContext.Trips.ToListAsync();
        }

        public void Update(Trip entity)
        {
            _dbContext.Trips.Update(entity);
        }
    }
}
