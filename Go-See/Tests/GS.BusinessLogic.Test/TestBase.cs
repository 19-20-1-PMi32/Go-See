using AutoMapper;
using GS.DataBase;
using Microsoft.EntityFrameworkCore;
using System;

namespace GS.BusinessLogic.Test
{
    public abstract class TestBase : IDisposable
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected abstract string ContextDBName { get; }

        protected TestBase()
        {
            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: ContextDBName)
                .Options;
            var context = new GSDbContext(options);
            _unitOfWork = new UnitOfWork(context);

            var entityDtoProfile = new EntityDtoProfile();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(entityDtoProfile);
            });
            _mapper = new Mapper(configuration);

        }

        public virtual void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
