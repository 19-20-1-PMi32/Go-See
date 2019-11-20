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
        }

        [Fact]
        public async Task GetUser_Existing_User()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            var user = await _service.GetUser(_testUser.Id);
            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(_testUser.Login, user.Login);
            Assert.Equal(_testUser.FirstName, user.FirstName);
            Assert.Equal(_testUser.LastName, user.LastName);
            Assert.Equal(_testUser.Email, user.Email);
            Assert.Equal(_testUser.Phone, user.Phone);
            Assert.Equal(_testUser.PasswordHash, user.PasswordHash);

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task GetUser_NotExisting_ThrowException()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.GetUser(Guid.NewGuid()));

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdateLogin_Existing_UpdatedLogin()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newLogin = "test";
            await _service.UpdateLogin(_testUser.Id, newLogin);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newLogin, user.Login);

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdateLogin_NotExisting_ThrowException()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newLogin = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateLogin(Guid.NewGuid(), newLogin));

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdateFirstName_Existing_UpdatedFirstName()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newFirstName = "test";
            await _service.UpdateFirstName(_testUser.Id, newFirstName);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newFirstName, user.FirstName);

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdateFirstName_NotExisting_ThrowException()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newFirstName = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateFirstName(Guid.NewGuid(), newFirstName));

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdateLastName_Existing_UpdatedLastName()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newLastName = "test";
            await _service.UpdateLastName(_testUser.Id, newLastName);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newLastName, user.LastName);

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdateLastName_NotExisting_ThrowException()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newLastName = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateLastName(Guid.NewGuid(), newLastName));

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdateEmail_Existing_UpdatedEmail()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newEmail = "test";
            await _service.UpdateEmail(_testUser.Id, newEmail);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newEmail, user.Email);

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdateEmail_NotExisting_ThrowException()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newEmail = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdateEmail(Guid.NewGuid(), newEmail));

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdatePhone_Existing_UpdatedPhone()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newPhone = "test";
            await _service.UpdatePhone(_testUser.Id, newPhone);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newPhone, user.Phone);

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdatePhone_NotExisting_ThrowException()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newPhone = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdatePhone(Guid.NewGuid(), newPhone));

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdatePasswordHash_Existing_UpdatedPasswordHash()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newPasswordHash = "test";
            await _service.UpdatePasswordHash(_testUser.Id, newPasswordHash);
            var user = await _unitOfWork.UserRepository.Get(_testUser.Id);

            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(newPasswordHash, user.PasswordHash);

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async Task UpdatePasswordHash_NotExisting_ThrowException()
        {
            // Setup
            _unitOfWork.UserRepository.Create(_testUser);
            await _unitOfWork.Commit();

            // Testing
            string newPasswordHash = "test";
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.UpdatePasswordHash(Guid.NewGuid(), newPasswordHash));

            // Teardown
            _unitOfWork.UserRepository.Delete(_testUser.Id);
            await _unitOfWork.Commit();
        }
    }
}
