using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GS.DataBaseTest
{
    public class UserRepositoryTest
    {
        public UserRepositoryTest() { }

        [Fact]
        public async Task Create()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestCreateUser"))
            {
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

                unitOfWork.UserRepository.Create(expectedUser);

                await unitOfWork.Commit().ConfigureAwait(true);

                var user = await unitOfWork.UserRepository.Get(expectedUser.Id).ConfigureAwait(true);

                Assert.Equal(expectedUser.Id, user.Id);
            }
        }



        [Fact]
        public async Task Delete()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestDeleteUser"))
            {
                var users = new List<DataBase.Entities.User>()
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


                unitOfWork.UserRepository.Create(users[0]);

                unitOfWork.UserRepository.Create(users[1]);

                unitOfWork.UserRepository.Delete(users[0].Id);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.UserRepository.GetAllAsync().ConfigureAwait(true);

                var newUsers = test.ToList();

                Assert.Single(newUsers);
            }
        }

        [Fact]
        public async Task Get()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetUser"))
            {
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

                unitOfWork.UserRepository.Create(expectedUser);

                await unitOfWork.Commit().ConfigureAwait(true);

                var user = await unitOfWork.UserRepository.Get(expectedUser.Id).ConfigureAwait(true);

                Assert.Equal(expectedUser.Id, user.Id);
            }
        }


        [Fact]
        public async Task GetAll()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetAllUser"))
            {
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

                unitOfWork.UserRepository.Create(user[0]);

                unitOfWork.UserRepository.Create(user[1]);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.UserRepository.GetAllAsync().ConfigureAwait(true);

                var length = test.ToList().Count;

                Assert.Equal(2, length);
            }
        }


        [Fact]
        public async Task Update()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestUpdateUser"))
            {
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

                unitOfWork.UserRepository.Create(expectedUser);

                await unitOfWork.Commit().ConfigureAwait(true);

                expectedUser.Id = Guid.NewGuid();

                unitOfWork.UserRepository.Update(expectedUser);

                var test = await unitOfWork.UserRepository.Get(expectedUser.Id).ConfigureAwait(true);

                Assert.Equal(expectedUser.Id, test.Id);
            }
        }
    }
}
