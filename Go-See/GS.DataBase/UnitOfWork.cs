using GS.DataBase.Repository;
using GS.DataBase.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.DataBase
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly GSDbContext _dbContext;

        #region Repositories
        public ICityRepository CityRepository =>
            CityRepository ?? new CityRepository(_dbContext);

        public IPlaceRepository PlaceRepository =>
            PlaceRepository ?? new PlaceRepository(_dbContext);

        public IReviewRepository ReviewRepository =>
            ReviewRepository ?? new ReviewRepository(_dbContext);

        public ITripNodeRepository TripNodeRepository =>
            TripNodeRepository ?? new TripNodeRepository(_dbContext);

        public ITripRepository TripRepository =>
            TripRepository ?? new TripRepository(_dbContext);

        public IUserRepository UserRepository =>
            UserRepository ?? new UserRepository(_dbContext);
        #endregion

        public UnitOfWork(GSDbContext dbContext)
        {
            _dbContext = dbContext;
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
