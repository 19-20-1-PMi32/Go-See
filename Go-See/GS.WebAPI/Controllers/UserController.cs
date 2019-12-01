using AutoMapper;
using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.WebAPI.Parameters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var user = await _userService.GetUser(userId);
            return Ok(user);
        }

        [HttpPost("new")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create([FromBody]UserParam value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newUser = _mapper.Map<User>(value);
            var userId = await _authenticationService.CreateUser(newUser);
            return Ok(userId);
        }

        [HttpPost("log-in")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> LogIn([FromBody]LogInParam value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = await _authenticationService.LogIn(value.Login, value.Password);
            return Ok(userId);
        }

        [HttpPatch("{userId}/update-login/")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateLogin(Guid userId, [FromBody]UserNameParam login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.UpdateLogin(userId, login.Value);
            return Ok();
        }

        [HttpPatch("{userId}/update-firstname/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdateFirstName(Guid userId, [FromBody]FirstNameParam firstname)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.UpdateFirstName(userId, firstname.Value);
            return Ok();
        }

        [HttpPatch("{userId}/update-lastname/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdateLastName(Guid userId, [FromBody]LastNameParam lastname)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.UpdateLastName(userId, lastname.Value);
            return Ok();
        }

        [HttpPatch("{userId}/update-email/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdateEmail(Guid userId, [FromBody]EmailParam email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.UpdateEmail(userId, email.Value);
            return Ok();
        }

        [HttpPatch("{userId}/update-phone/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdatePhone(Guid userId, [FromBody]PhoneParam phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.UpdatePhone(userId, phone.Value);
            return Ok();
        }

        [HttpPatch("{userId}/update-password/")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdatePassword(Guid userId, [FromBody]PasswordParam passwordHash)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.UpdatePasswordHash(userId, passwordHash.Value);
            return Ok();
        }
    }
}
