using GS.BusinessLogic.Contracts;
using GS.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GS.BusinessLogic.Test
{
    public class UserServiceTest : TestBase
    {
        private readonly IUserService _service;

        private readonly User _testUser;

        protected override string ContextDBName => "User Service Test";

        public UserServiceTest() : base()
        {
            _service = new UserService(_unitOfWork, _mapper);

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

            _unitOfWork.UserRepository.Create(_testUser);
            _unitOfWork.Commit().Wait();
        }

        public override void Dispose()
        {
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            _unitOfWork.Commit().Wait();
            base.Dispose();
        }

        [Fact]
        public async Task GetUser_Existing_User()
        {
            var user = await _service.GetUser(_testUser.Id);
            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(_testUser.Login, user.Login);
            Assert.Equal(_testUser.FirstName, user.FirstName);
            Assert.Equal(_testUser.LastName, user.LastName);
            Assert.Equal(_testUser.Email, user.Email);
            Assert.Equal(_testUser.Phone, user.Phone);
            Assert.Equal(_testUser.PasswordHash, user.PasswordHash);
        }

        [Fact]
        public async Task GetUser_NotExisting_ThrowException()
        {
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.GetUser(Guid.NewGuid()));
        }

        [Fact]
        public async Task UpdateLogin_Existing_UpdatedLogin()
        {
            string newLogin = "test";
            await _service.UpdateLogin(_testUser.Id, newLogin);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newLogin, user.Login);
        }

        [Fact]
        public async Task UpdateLogin_NotExisting_ThrowException()
        {
            string newLogin = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateLogin(Guid.NewGuid(), newLogin));
        }

        [Fact]
        public async Task UpdateFirstName_Existing_UpdatedFirstName()
        {
            string newFirstName = "test";
            await _service.UpdateFirstName(_testUser.Id, newFirstName);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newFirstName, user.FirstName);
        }

        [Fact]
        public async Task UpdateFirstName_NotExisting_ThrowException()
        {
            string newFirstName = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateFirstName(Guid.NewGuid(), newFirstName));
        }

        [Fact]
        public async Task UpdateLastName_Existing_UpdatedLastName()
        {
            string newLastName = "test";
            await _service.UpdateLastName(_testUser.Id, newLastName);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newLastName, user.LastName);
        }

        [Fact]
        public async Task UpdateLastName_NotExisting_ThrowException()
        {
            string newLastName = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateLastName(Guid.NewGuid(), newLastName));
        }

        [Fact]
        public async Task UpdateEmail_Existing_UpdatedEmail()
        {
            string newEmail = "test";
            await _service.UpdateEmail(_testUser.Id, newEmail);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newEmail, user.Email);
        }

        [Fact]
        public async Task UpdateEmail_NotExisting_ThrowException()
        {
            string newEmail = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateEmail(Guid.NewGuid(), newEmail));
        }

        [Fact]
        public async Task UpdatePhone_Existing_UpdatedPhone()
        {
            string newPhone = "test";
            await _service.UpdatePhone(_testUser.Id, newPhone);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newPhone, user.Phone);
        }

        [Fact]
        public async Task UpdatePhone_NotExisting_ThrowException()
        {
            string newPhone = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdatePhone(Guid.NewGuid(), newPhone));
        }

        [Fact]
        public async Task UpdatePasswordHash_Existing_UpdatedPasswordHash()
        {
            string newPasswordHash = "test";
            await _service.UpdatePasswordHash(_testUser.Id, newPasswordHash);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newPasswordHash, user.PasswordHash);
        }

        [Fact]
        public async Task UpdatePasswordHash_NotExisting_ThrowException()
        {
            string newPasswordHash = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdatePasswordHash(Guid.NewGuid(), newPasswordHash));
        }
    }
}
