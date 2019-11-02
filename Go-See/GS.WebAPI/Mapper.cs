using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.DTO;
using GS.WebAPI.Parameters;

namespace GS.WebAPI
{
    public static class Mapper
    {
        public static User MapUserParam(UserParam param)
        {
            return new User
            {
                Login = param.Login,
                FirstName = param.FirstName,
                LastName = param.LastName,
                Email = param.Email,
                Phone = param.Phone,
                PasswordHash = param.PasswordHash
            };
        }
    }
}
