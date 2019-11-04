using GS.BusinessLogic.Contracts;
using GS.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GS.BusinessLogic.Test
{
    public class AuthenticationServiceTest : TestBase
    {
        private readonly IAuthenticationService _service;

        private readonly Guid _testUserId = Guid.NewGuid();
        private readonly string _testUserPasswordHash = "TestPasswordHash";

        protected override string ContextDBName => "Auth Service Test";

        public AuthenticationServiceTest() : base()
        {
            _service = new AuthenticationService(_unitOfWork);
        }

        [Fact]
        public async Task LogIn_AlreadyRegistered_UserId()
        {
            var _testUser = new User
            {
                Id = _testUserId,
                Login = "Test1",
                PasswordHash = _testUserPasswordHash,
                FirstName = "Test1",
                LastName = "Test1",
                Email = "test1@gmail.com",
                Phone = "123"
            };
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            var userId = await _service.LogIn(_testUser.Login, _testUser.PasswordHash);
            Assert.Equal(_testUser.Id, userId);
        }

        [Fact]
        public async Task LogIn_NotRegistered_ThrowException()
        {
            var otherLogin = "otherTestUser";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.LogIn(otherLogin, _testUserPasswordHash));
        }

        [Fact]
        public async Task CreateUser_NotRegistered_UserId()
        {
            var _testUser = new Core.DTO.User
            {
                Login = "Test2",
                PasswordHash = _testUserPasswordHash,
                FirstName = "Test2",
                LastName = "Test2",
                Email = "test2@gmail.com",
                Phone = "321"
            };

            var userId = await _service.CreateUser(_testUser);
            Assert.True(userId != Guid.Empty);
        }

        [Fact]
        public async Task CreateUser_AlreadyRegistered_ThrowException()
        {
            var _testUser = new Core.DTO.User
            {
                Login = "Test2",
                PasswordHash = _testUserPasswordHash,
                FirstName = "Test2",
                LastName = "Test2",
                Email = "test2@gmail.com",
                Phone = "321"
            };
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.CreateUser(_testUser));
        }
    }
}
