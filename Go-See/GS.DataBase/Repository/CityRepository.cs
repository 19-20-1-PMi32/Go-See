using GS.DataBase.Entities;
using GS.DataBase.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.DataBase.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly GSDbContext _dbContext;

        public CityRepository(GSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _dbContext.Cities.ToListAsync();
        }

        public async Task<City> Get(Guid id)
        {
            return await _dbContext.Cities.FindAsync(id);
        }

        public async Task<City> GetByName(string cityName)
        {
            return await _dbContext.Cities.FirstOrDefaultAsync(x => x.Name == cityName);
        }

        public void Create(City entity)
        {
            _dbContext.Cities.Add(entity);
        }

        public void Update(City entity)
        {
            _dbContext.Cities.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            var city = await _dbContext.Cities.FindAsync(id);
            if (city != null)
            {
                _dbContext.Cities.Remove(city);
            }
        }
    }
}