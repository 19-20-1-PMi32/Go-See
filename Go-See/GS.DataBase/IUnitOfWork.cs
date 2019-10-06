using System;
using System.Collections.Generic;
using System.Text;

namespace GS.DataBase
{
    interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
