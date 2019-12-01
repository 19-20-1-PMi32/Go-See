using AutoMapper;
using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            var cities = await _unitOfWork.CityRepository.GetAll();
            return _mapper.Map<IEnumerable<City>>(cities);
        }

        public async Task<IEnumerable<CityWithPlaces>> GetAllWithPlaces()
        {
            var cities = await _unitOfWork.CityRepository.GetAll();
            var citiesWithPlaces = new List<CityWithPlaces>();

            foreach (var city in cities)
            {
                var places = await _unitOfWork.PlaceRepository.GetAll();
                var cityPlaces = _mapper.Map<IEnumerable<Place>>(places.Where(x => x.CityId == city.Id));

                var citywithPlaces = new CityWithPlaces()
                {
                    Id = city.Id,
                    Name = city.Name,
                    Country = city.Country,
                    Description = city.Description,
                    IsCapital = city.IsCapital,
                    Places = cityPlaces
                };
                citiesWithPlaces.Add(citywithPlaces);
            }

            return citiesWithPlaces;
        }

        public async Task<City> GetById(Guid cityId)
        {
            var city = await _unitOfWork.CityRepository.Get(cityId);
            return _mapper.Map<City>(city);
        }

        public async Task<CityWithPlaces> GetByIdWithPlaces(Guid cityId)
        {
            var city = await _unitOfWork.CityRepository.Get(cityId);
            var places = await _unitOfWork.PlaceRepository.GetAll();

            var cityPlaces = _mapper.Map<IEnumerable<Place>>(places.Where(x => x.CityId == city.Id));

            var citywithPlaces = new CityWithPlaces()
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country,
                Description = city.Description,
                IsCapital = city.IsCapital,
                Places = cityPlaces
            };

            return citywithPlaces;
        }

        public async Task<CityWithPlaces> GetByNameWithPlaces(string cityName)
        {
            var city = await _unitOfWork.CityRepository.GetByName(cityName);
            var places = await _unitOfWork.PlaceRepository.GetAll();

            var cityPlaces = _mapper.Map<IEnumerable<Place>>(places.Where(x => x.CityId == city.Id));

            var citywithPlaces = new CityWithPlaces()
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country,
                Description = city.Description,
                IsCapital = city.IsCapital,
                Places = cityPlaces
            };

            return citywithPlaces;
        }
    }
}
