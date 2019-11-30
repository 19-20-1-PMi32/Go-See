using System;
using System.Net;
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

        [HttpPatch("{id}/update-login/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdateLogin(Guid id, [FromBody]string login)
        {
            await _userService.UpdateLogin(id, login);
            return Ok();
        }

        [HttpPatch("{id}/update-firstname/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdateFirstName(Guid id, [FromBody]string firstname)
        {
            await _userService.UpdateFirstName(id, firstname);
            return Ok();
        }

        [HttpPatch("{id}/update-lastname/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdateLastName(Guid id, [FromBody]string lastname)
        {
            await _userService.UpdateLastName(id, lastname);
            return Ok();
        }

        [HttpPatch("{id}/update-email/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdateEmail(Guid id, [FromBody]string email)
        {
            await _userService.UpdateEmail(id, email);
            return Ok();
        }

        [HttpPatch("{id}/update-phone/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdatePhone(Guid id, [FromBody]string phone)
        {
            await _userService.UpdatePhone(id, phone);
            return Ok();
        }

        [HttpPatch("{id}/update-password/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdatePassword(Guid id, [FromBody]string passwordHash)
        {
            await _userService.UpdatePasswordHash(id, passwordHash);
            return Ok();
        }
    }
}
