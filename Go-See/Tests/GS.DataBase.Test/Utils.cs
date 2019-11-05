using GS.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.DataBaseTest
{
    public static class Utils
    {
        public static IUnitOfWork GetUnitOfWork(string name)
        {
            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;

            var context = new GSDbContext(options, false);

            return new UnitOfWork(context);
        }
    }
}
