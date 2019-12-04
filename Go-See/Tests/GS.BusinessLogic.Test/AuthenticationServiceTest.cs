using GS.BusinessLogic.Contracts;
using GS.BusinessLogic.Services;
using GS.DataBase.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GS.BusinessLogic.Test
{
    public class AuthenticationServiceTest : TestBase
    {
        private readonly IAuthenticationService _service;

        protected override string ContextDBName => "Auth Service Test";

        public AuthenticationServiceTest() : base()
        {
            _service = new AuthenticationService(_unitOfWork, _mapper);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        [Fact]
        public async Task LogIn_AlreadyRegistered_UserId()
        {
            var userId = await _service.LogIn(_testUser.Login, _testUser.PasswordHash);
            Assert.Equal(_testUser.Id, userId);
        }

        [Fact]
        public async Task LogIn_NotRegistered_ThrowException()
        {
            var otherLogin = "otherTestUser";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.LogIn(otherLogin, _testUser.PasswordHash));
        }

        [Fact]
        public async Task LogIn_WrongPassword_ThrowException()
        {
            var otherPassword = "otherTestUser";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.LogIn(_testUser.Login, otherPassword));
        }

        [Fact]
        public async Task CreateUser_NotRegistered_UserId()
        {
            var _newUser = new Core.DTO.User
            {
                Login = "Test2",
                PasswordHash = "TestPasswordHash2",
                FirstName = "Test2",
                LastName = "Test2",
                Email = "test2@gmail.com",
                Phone = "321"
            };

            var userId = await _service.CreateUser(_newUser);
            Assert.True(userId != Guid.Empty);
        }

        [Fact]
        public async Task CreateUser_AlreadyRegistered_ThrowException()
        {
            var _newUser = new Core.DTO.User
            {
                Login = _testUser.Login,
                PasswordHash = "TestPasswordHash2",
                FirstName = "Test2",
                LastName = "Test2",
                Email = "test2@gmail.com",
                Phone = "321"
            };
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.CreateUser(_newUser));
        }
    }
}
