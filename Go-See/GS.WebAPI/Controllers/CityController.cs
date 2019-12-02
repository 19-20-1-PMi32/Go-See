using GS.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GS.WebAPI.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET api/city
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.GetAll();
            return Ok(cities);
        }

        // GET api/city/places
        [HttpGet("places")]
        public async Task<IActionResult> GetAllWithPlaces()
        {
            var cities = await _cityService.GetAllWithPlaces();
            return Ok(cities);
        }

        // GET api/city/id/00000000-0000-0000-0000-000000000000/places
        [HttpGet("id/{cityId}/places")]
        public async Task<IActionResult> GetByIdWithPlaces(Guid cityId)
        {
            var city = await _cityService.GetByIdWithPlaces(cityId);
            return Ok(city);
        }

        // GET api/city/name/Lviv/places
        [HttpGet("name/{cityName}/places")]
        public async Task<IActionResult> GetByIdWithPlaces(string cityName)
        {
            var city = await _cityService.GetByNameWithPlaces(cityName);
            return Ok(city);
        }
    }
}