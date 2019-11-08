using GS.DataBase.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.DataBase
{
    public interface IUnitOfWork : IDisposable
    {
         ICityRepository CityRepository { get; }

         IPlaceRepository PlaceRepository { get; }

         IReviewRepository ReviewRepository { get; }

         ITripNodeRepository TripNodeRepository { get; }

         ITripRepository TripRepository { get; }

         IUserRepository UserRepository { get; }

        Task Commit();

        void Rollback();
    }
}
