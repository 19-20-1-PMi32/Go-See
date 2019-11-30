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
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlaceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            var places = await _unitOfWork.PlaceRepository.GetAll();
            return _mapper.Map<IEnumerable<Place>>(places);
        }

        public async Task<IEnumerable<Place>> GetByCityId(Guid cityId)
        {
            var places = await _unitOfWork.PlaceRepository.GetAll();
            var cityPlaces = places.Where(x => x.CityId == cityId);

            return _mapper.Map<IEnumerable<Place>>(cityPlaces);
        }

        public async Task<Place> GetByPlaceId(Guid placeId)
        {
            var place = await _unitOfWork.PlaceRepository.Get(placeId);

            return _mapper.Map<Place>(place);
        }
    }
}
