using GS.DataBase.Repository;
using GS.DataBase.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.DataBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GSDbContext _dbContext;

        #region Repositories
        public ICityRepository CityRepository { get; }

        public IPlaceRepository PlaceRepository { get; }

        public IReviewRepository ReviewRepository { get; }

        public ITripNodeRepository TripNodeRepository { get; }

        public ITripRepository TripRepository { get; }

        public IUserRepository UserRepository { get; }
        #endregion

        public UnitOfWork(GSDbContext dbContext)
        {
            _dbContext = dbContext;
            CityRepository = new CityRepository(_dbContext);
            PlaceRepository = new PlaceRepository(_dbContext);
            ReviewRepository = new ReviewRepository(_dbContext);
            TripNodeRepository = new TripNodeRepository(_dbContext);
            TripRepository = new TripRepository(_dbContext);
            UserRepository = new UserRepository(_dbContext);
        }

        public async void Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        await entry.ReloadAsync();
                        break;
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
