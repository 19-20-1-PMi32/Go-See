using AutoMapper;
using GS.Core.DTO;
using GS.WebAPI.Parameters;

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
