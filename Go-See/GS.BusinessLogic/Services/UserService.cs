using AutoMapper;
using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.DataBase;
using System;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        private async Task<DataBase.Entities.User> GetUserEntity(Guid userId)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
                return userEntity;
            }
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }

        public async Task<User> GetUser(Guid userId)
        {
            var userEntity = await GetUserEntity(userId);

            var user = _mapper.Map<User>(userEntity);

            return user;
        }

        public async Task UpdateLogin(Guid userId, string newLogin)
        {
            var userEntity = await GetUserEntity(userId);

            userEntity.Login = newLogin;

            _unitOfWork.UserRepository.Update(userEntity);

            await _unitOfWork.Commit();
        }

        public async Task UpdateFirstName(Guid userId, string newFirstName)
        {
            var userEntity = await GetUserEntity(userId);

            userEntity.FirstName = newFirstName;

            _unitOfWork.UserRepository.Update(userEntity);

            await _unitOfWork.Commit();
        }

        public async Task UpdateLastName(Guid userId, string newLastName)
        {
            var userEntity = await GetUserEntity(userId);

            userEntity.LastName = newLastName;

            _unitOfWork.UserRepository.Update(userEntity);

            await _unitOfWork.Commit();
        }

        public async Task UpdateEmail(Guid userId, string newEmail)
        {
            var userEntity = await GetUserEntity(userId);

            userEntity.Email = newEmail;

            _unitOfWork.UserRepository.Update(userEntity);

            await _unitOfWork.Commit();
        }

        public async Task UpdatePhone(Guid userId, string newPhone)
        {
            var userEntity = await GetUserEntity(userId);

            userEntity.Phone = newPhone;

            _unitOfWork.UserRepository.Update(userEntity);

            await _unitOfWork.Commit();
        }

        public async Task UpdatePasswordHash(Guid userId, string newPasswordHash)
        {
            var userEntity = await GetUserEntity(userId);

            userEntity.PasswordHash = newPasswordHash;

            _unitOfWork.UserRepository.Update(userEntity);

            await _unitOfWork.Commit();
        }
    }
}
