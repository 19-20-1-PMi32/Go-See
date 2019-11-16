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

            CreateMap<Core.DTO.City, DataBase.Entities.City>();
            CreateMap<Core.DTO.Place, DataBase.Entities.Place>();
            CreateMap<Core.DTO.Review, DataBase.Entities.Review>();
            CreateMap<Core.DTO.Trip, DataBase.Entities.Trip>();
            CreateMap<Core.DTO.TripNode, DataBase.Entities.TripNode>();
            CreateMap<Core.DTO.User, DataBase.Entities.User>();
        }
    }
}
