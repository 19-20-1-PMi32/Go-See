using GS.DataBase;
using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.BusinessLogic.Test
{
    public abstract class TestBase
    {
        protected readonly UnitOfWork _unitOfWork;

        protected abstract string ContextDBName { get; }

        protected TestBase()
        {
            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: ContextDBName)
                .Options;

            var context = new GSDbContext(options, false);

            _unitOfWork = new UnitOfWork(context);
        }
    }
}
