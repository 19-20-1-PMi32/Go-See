using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.BusinessLogic;
using GS.BusinessLogic.Contracts;
using GS.Core.DTO;
using GS.DataBase;
using GS.WebAPI.Parameters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GS.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IUserService userService;
        private IAuthenticationService authenticationService;

        public UserController()
        {
            var contextFactory = new GSDbContextFactory();
            unitOfWork = new UnitOfWork(contextFactory.CreateDbContext(new string[] { }));
            userService = new UserService(unitOfWork);
            authenticationService = new AuthenticationService(unitOfWork);
        }

        // GET api/user/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await userService.GetUser(id);
            return Ok(user);
        }

        [HttpPost("new")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create([FromBody]UserParam value)
        {
            var newUser = new User()
            {
                FirstName = value.FirstName,
                LastName = value.LastName,
                Phone = value.Phone,
                Email = value.Email,
                Login = value.Login,
                PasswordHash = value.PasswordHash
            };
            var userId = await authenticationService.CreateUser(newUser);
            return Ok(userId);
        }

        [HttpPost("log-in")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> LogIn([FromBody]LogInParam value)
        {
            var userId = await authenticationService.LogIn(value.Login, value.Password);
            return Ok(userId);
        }
    }
}
