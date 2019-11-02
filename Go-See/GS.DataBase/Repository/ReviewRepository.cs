using GS.DataBase.Entities;
using GS.DataBase.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.DataBase.Repository
{
    class ReviewRepository : IReviewRepository
    {
        private readonly GSDbContext _dbContext;

        public ReviewRepository(GSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Review entity)
        {
            _dbContext.Reviews.Add(entity);
        }

        public async void Delete(Guid id)
        {
            var review = await _dbContext.Reviews.FindAsync(id);
            if (review != null)
            {
                _dbContext.Reviews.Remove(review);
            }
        }

        public async Task<Review> Get(Guid id)
        {
            return await _dbContext.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _dbContext.Reviews.ToListAsync();
        }

        public void Update(Review entity)
        {
            _dbContext.Reviews.Update(entity);
        }
    }
}
