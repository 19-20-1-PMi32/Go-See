using GS.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GS.DataBaseTest
{
    public class UserRepositoryTest
    {
        public UserRepositoryTest() { }

        public UnitOfWork UnitOfWork { get; set; }

        public UnitOfWork GetOption(string name)
        {
            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;

            var context = new GSDbContext(options);

            UnitOfWork = new UnitOfWork(context);

            return UnitOfWork;

        }

        [Fact]
        public async Task Create()
        {

            UnitOfWork = GetOption("TestCreateUser");

            var expectedUser = new DataBase.Entities.User()
            {
                Id = Guid.NewGuid(),
                Login = "jackleo",
                FirstName = "Jack",
                LastName = "Leonardo",
                Email = "jackleo@mail.com",
                Phone = "380942378556",
                PasswordHash = "lack1999"
            };

            UnitOfWork.UserRepository.Create(expectedUser);

            UnitOfWork.Commit();

            var user =  UnitOfWork.UserRepository.Get(Guid.NewGuid());

            Assert.Equal(expectedUser.Id, user.Id);

        }



        [Fact]
        public async Task Delete()
        {

            UnitOfWork = GetOption("TestDeleteUser");


            var user = new List<DataBase.Entities.User>()
            {
                new DataBase.Entities.User()
            {
                Id = Guid.NewGuid(),
                Login = "jackleo",
                FirstName = "Jack",
                LastName = "Leonardo",
                Email = "jackleo@mail.com",
                Phone = "380942378556",
                PasswordHash = "lack1999"
            },

            new DataBase.Entities.User()
            {
                Id = Guid.NewGuid(),
                Login = "lucyduvet",
                FirstName = "Lucy",
                LastName = "Duveteri",
                Email = "",
                Phone = "380992649101",
                PasswordHash = "2012LuDu"
            }

            };
        

            UnitOfWork.UserRepository.Create(user[0]);

            UnitOfWork.UserRepository.Create(user[1]);

            UnitOfWork.UserRepository.Delete(Guid.NewGuid());

            UnitOfWork.Commit();

            var test =  UnitOfWork.UserRepository.GetAllAsync();

            List<DataBase.Entities.User> users = test.ToList();

            Assert.Equal(1, users.Count());

        }

        [Fact]
        public async Task Get()
        {

            UnitOfWork = GetOption("TestGetUser");

            var expectedUser = new DataBase.Entities.User()
            {
                Id = Guid.NewGuid(),
                Login = "jackleo",
                FirstName = "Jack",
                LastName = "Leonardo",
                Email = "jackleo@mail.com",
                Phone = "380942378556",
                PasswordHash = "lack1999"
            };

            UnitOfWork.UserRepository.Create(expectedUser);

            UnitOfWork.Commit();

            var user = await UnitOfWork.UserRepository.Get(Guid.NewGuid());

            Assert.Equal(expectedUser.Id, user.Id);

        }


        [Fact]
        public async Task GetAll()
        {

            UnitOfWork = GetOption("TestGetAllUser");


            var user = new List<DataBase.Entities.User>()
            {
                new DataBase.Entities.User()
                {
                    Id = Guid.NewGuid(),
                    Login = "jackleo",
                    FirstName = "Jack",
                    LastName = "Leonardo",
                    Email = "jackleo@mail.com",
                    Phone = "380942378556",
                    PasswordHash = "lack1999"
                },

                new DataBase.Entities.User()
                {
                    Id = Guid.NewGuid(),
                    Login = "lucyduvet",
                    FirstName = "Lucy",
                    LastName = "Duveteri",
                    Email = "",
                    Phone = "380992649101",
                    PasswordHash = "2012LuDu"
                }
             };

            UnitOfWork.UserRepository.Create(user[0]);

            UnitOfWork.UserRepository.Create(user[1]);

            UnitOfWork.Commit();

            var test = await UnitOfWork.UserRepository.GetAllAsync();

            List<DataBase.Entities.User> users = test.ToList();

            Assert.Equal(2, users.Count());

        }


        [Fact]
        public async Task Update()
        {

            UnitOfWork = GetOption("TestUpdateUser");


            var expectedUser = new DataBase.Entities.User()
            {
                Id = Guid.NewGuid(),
                Login = "jackleo",
                FirstName = "Jack",
                LastName = "Leonardo",
                Email = "jackleo@mail.com",
                Phone = "380942378556",
                PasswordHash = "lack1999"
            };

            UnitOfWork.UserRepository.Create(expectedUser);

            UnitOfWork.Commit();

            expectedUser.Id = Guid.NewGuid();

            UnitOfWork.UserRepository.Update(expectedUser);

            var test = await UnitOfWork.UserRepository.Get(Guid.NewGuid());

            Assert.Equal(expectedUser.Id, test.Id);

        }
    }
}
