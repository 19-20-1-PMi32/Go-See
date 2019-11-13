using AutoMapper;
using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> GetUser(Guid userId)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
                var user = _mapper.Map<User>(userEntity);

                return user;
            }
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }

        public async Task UpdateLogin(Guid userId, string newLogin)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
                userEntity.Login = newLogin;
                _unitOfWork.UserRepository.Update(userEntity);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }

        public async Task UpdateFirstName(Guid userId, string newFirstName)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
                userEntity.FirstName = newFirstName;
                _unitOfWork.UserRepository.Update(userEntity);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }

        public async Task UpdateLastName(Guid userId, string newLastName)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
                userEntity.LastName = newLastName;
                _unitOfWork.UserRepository.Update(userEntity);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }

        public async Task UpdateEmail(Guid userId, string newEmail)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
                userEntity.Email = newEmail;
                _unitOfWork.UserRepository.Update(userEntity);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }

        public async Task UpdatePhone(Guid userId, string newPhone)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
                userEntity.Phone = newPhone;
                _unitOfWork.UserRepository.Update(userEntity);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }

        public async Task UpdatePasswordHash(Guid userId, string newPasswordHash)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(userId);

            if (userEntity != null)
            {
                userEntity.PasswordHash = newPasswordHash;
                _unitOfWork.UserRepository.Update(userEntity);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Can not find user with such id");
            }
        }
    }
}
