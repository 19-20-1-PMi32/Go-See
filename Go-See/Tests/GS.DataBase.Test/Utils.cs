using GS.DataBase;
using Microsoft.EntityFrameworkCore;

namespace GS.DataBaseTest
{
    public static class Utils
    {
        public static IUnitOfWork GetUnitOfWork(string name)
        {
            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;

            var context = new GSDbContext(options);

            return new UnitOfWork(context);
        }
    }
}
