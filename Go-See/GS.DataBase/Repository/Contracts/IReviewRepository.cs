using System.Collections.Generic;
using System.Threading.Tasks;
using GS.DataBase.Entities;

namespace GS.DataBase.Repository.Contracts
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAll();
        
        Task<Review> Get(int id);
        
        void Create(Review entity);
        
        void Update(Review entity);
        
        void Delete(int id);
    }
}