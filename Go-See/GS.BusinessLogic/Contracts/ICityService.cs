﻿using GS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.BusinessLogic.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAll();

        Task<City> GetById(Guid cityId);

        Task<IEnumerable<CityWithPlaces>> GetAllWithPlaces();

        Task<CityWithPlaces> GetByIdWithPlaces(Guid cityId);

        Task<CityWithPlaces> GetByNameWithPlaces(string cityName);
    }
}
