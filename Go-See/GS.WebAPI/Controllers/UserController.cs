using System;
using System.Threading.Tasks;
using AutoMapper;
using GS.BusinessLogic;
using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.DataBase;
using GS.WebAPI.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace GS.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IAuthenticationService authenticationService, IMapper mapper)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        // GET api/user/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpPost("new")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create([FromBody]UserParam value)
        {
            var newUser = _mapper.Map<User>(value);
            var userId = await _authenticationService.CreateUser(newUser);
            return Ok(userId);
        }

        [HttpPost("log-in")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> LogIn([FromBody]LogInParam value)
        {
            var userId = await _authenticationService.LogIn(value.Login, value.Password);
            return Ok(userId);
        }
    }
}
