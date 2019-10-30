using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.DataBase
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();

        void Rollback();
    }
}
