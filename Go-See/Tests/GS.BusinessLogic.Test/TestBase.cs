using AutoMapper;
using GS.DataBase;
using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GS.BusinessLogic.Test
{
    public abstract class TestBase : IDisposable
    {
        private readonly GSDbContext _context;

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        protected readonly User _testUser;
        protected readonly Trip _testTrip;
        protected readonly List<TripNode> _testTripNodes;

        protected abstract string ContextDBName { get; }

        protected TestBase()
        {


            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: ContextDBName)
                .Options;
            _context = new GSDbContext(options);

            _testUser = new User
            {
                Id = Guid.NewGuid(),
                Login = "Test1",
                PasswordHash = "testpasswordhash",
                FirstName = "Test1",
                LastName = "Test1",
                Email = "test1@gmail.com",
                Phone = "123"
            };
            _testTrip = new Trip
            {
                Id = Guid.NewGuid(),
                Name = "Trip1",
                UserId = _testUser.Id
            };
            _testTripNodes = new List<TripNode>
            {
                new TripNode
                {
                    Id = Guid.NewGuid(),
                    TripId = _testTrip.Id,
                    PlaceId = Guid.NewGuid(),
                    SequenceNumber = 1
                },
                new TripNode
                {
                    Id = Guid.NewGuid(),
                    TripId = _testTrip.Id,
                    PlaceId = Guid.NewGuid(),
                    SequenceNumber = 2
                },
                new TripNode
                {
                    Id = Guid.NewGuid(),
                    TripId = _testTrip.Id,
                    PlaceId = Guid.NewGuid(),
                    SequenceNumber = 3
                },
                new TripNode
                {
                    Id = Guid.NewGuid(),
                    TripId = _testTrip.Id,
                    PlaceId = Guid.NewGuid(),
                    SequenceNumber = 4
                }
            };
            _context.Add(_testUser);
            _context.Add(_testTrip);
            _context.AddRange(_testTripNodes);
            _context.SaveChanges();

            _unitOfWork = new UnitOfWork(_context);

            var entityDtoProfile = new EntityDtoProfile();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(entityDtoProfile);
            });
            _mapper = new Mapper(configuration);

        }

        public virtual void Dispose()
        {
            foreach (var user in _context.Users)
            {
                _context.Remove(user);
            }
            foreach (var trip in _context.Trips)
            {
                _context.Remove(trip);
            }
            foreach (var tripNode in _context.TripNodes)
            {
                _context.Remove(tripNode);
            }
            _context.SaveChanges();
            _unitOfWork.Dispose();
        }
    }
}
