using AutoMapper;
using GS.Core.DTO;
using GS.WebAPI.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS.WebAPI
{
    public class ParametersDtoProfile : Profile
    {
        public ParametersDtoProfile()
        { 
            CreateMap<UserParam, User>();
        }
    }
}
