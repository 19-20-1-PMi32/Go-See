using GS.BusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.BusinessLogic.Test
{
    public class UserServiceTest : TestBase
    {
        private readonly IUserService _service;

        protected override string ContextDBName => "User Service Test";

        public UserServiceTest() : base()
        {

        }
    }
}
