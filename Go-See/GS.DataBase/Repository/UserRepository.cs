using GS.DataBase.Entities;
using GS.DataBase.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.DataBase.Repository
{
    class UserRepository : IUserRepository
    {
        private readonly GSDbContext _dbContext;

        public UserRepository(GSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(User entity)
        {
            _dbContext.Users.Add(entity);
        }

        public async void Delete(string id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
            }
        }

        public async Task<User> Get(string id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
        }
    }
}
