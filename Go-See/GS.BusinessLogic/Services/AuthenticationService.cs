using AutoMapper;
using GS.BusinessLogic.Contracts;
using GS.DataBase;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<Guid> CreateUser(Core.DTO.User userParam)
        {
            var isExist = (await _unitOfWork.UserRepository.GetAllAsync())
                .Any(x => x.Login == userParam.Login);

            if (!isExist)
            {
                var id = Guid.NewGuid();
                var user = _mapper.Map<DataBase.Entities.User>(userParam);
                user.Id = id;

                _unitOfWork.UserRepository.Create(user);
                await _unitOfWork.Commit();

                return id;
            }

            throw new ArgumentException("User already exist");
        }

        public async Task<Guid> LogIn(string username, string password)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            var user = users.Where(entry => entry.Login == username).FirstOrDefault();

            if (user != null && user.PasswordHash == password)
            {
                return user.Id;
            }

            throw new ArgumentException("Wrong password or login");
        }
    }
}
