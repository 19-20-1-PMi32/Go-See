using System;
using System.Collections.Generic;
using System.Text;

namespace GS.DataBase
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
