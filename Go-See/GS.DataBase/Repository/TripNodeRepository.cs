using GS.DataBase.Entities;
using GS.DataBase.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.DataBase.Repository
{
    class TripNodeRepository : ITripNodeRepository
    {
        private readonly GSDbContext _dbContext;

        public TripNodeRepository(GSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TripNode entity)
        {
            _dbContext.TripNodes.Add(entity);
        }

        public async void Delete(Guid id)
        {
            var tripNode = await _dbContext.TripNodes.FindAsync(id);
            if (tripNode != null)
            {
                _dbContext.TripNodes.Remove(tripNode);
            }
        }

        public async Task<TripNode> Get(Guid id)
        {
            return await _dbContext.TripNodes.FindAsync(id);
        }

        public async Task<IEnumerable<TripNode>> GetAll()
        {
            return await _dbContext.TripNodes.ToListAsync();
        }

        public void Update(TripNode entity)
        {
            _dbContext.TripNodes.Update(entity);
        }

        public async Task CreateRange(List<TripNode> tripNodes)
        {
            await _dbContext.AddRangeAsync(tripNodes);
        }

        public async Task DeleteByTripId(Guid id)
        {
            var tripNodes = await _dbContext.TripNodes.ToListAsync();
            foreach (var tripNode in tripNodes)
            {
                if (tripNode.TripId == id)
                {
                    _dbContext.TripNodes.Remove(tripNode);
                }
            }
        }
    }






}
