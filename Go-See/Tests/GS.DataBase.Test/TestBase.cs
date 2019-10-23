using System;
using System.Collections.Generic;
using System.Text;
using GS.DataBase;
using Microsoft.EntityFrameworkCore;

namespace GS.DataBaseTest
{
    public class TestBase
    {
        public UnitOfWork UnitOfWork { get; set; }
        public TestBase()
        {
            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            var context = new GSDbContext(options);

            UnitOfWork = new UnitOfWork(context);

        }
    }
}
