using AutoMapper;
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
    }
}
