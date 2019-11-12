using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.BusinessLogic
{
    public class EntityDtoProfile : Profile
    {
        public EntityDtoProfile()
        {
            CreateMap<DataBase.Entities.City, Core.DTO.City>();
            CreateMap<DataBase.Entities.Place, Core.DTO.Place>();
            CreateMap<DataBase.Entities.Review, Core.DTO.Review>();
            CreateMap<DataBase.Entities.Trip, Core.DTO.Trip>();
            CreateMap<DataBase.Entities.TripNode, Core.DTO.TripNode>();
            CreateMap<DataBase.Entities.User, Core.DTO.User>();
        }
    }
}
