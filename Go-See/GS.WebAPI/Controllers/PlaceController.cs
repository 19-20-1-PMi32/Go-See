using GS.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GS.WebAPI.Controllers
{
    [Route("api/place")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        // GET api/place
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var places = await _placeService.GetAll();
            return Ok(places);
        }

        // GET api/place/city/00000000-0000-0000-0000-000000000000
        [HttpGet("city/{cityId}")]
        public async Task<IActionResult> GetByCityId(Guid cityId)
        {
            var place = await _placeService.GetByCityId(cityId);
            return Ok(place);
        }

    }
}