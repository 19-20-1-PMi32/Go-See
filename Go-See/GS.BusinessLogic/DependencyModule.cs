using Autofac;
using GS.BusinessLogic.Contracts;
using GS.BusinessLogic.Services;

namespace GS.BusinessLogic
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<PlaceService>().As<IPlaceService>();
            builder.RegisterType<CityService>().As<ICityService>();

            builder.RegisterModule<DataBase.DependencyModule>();
        }
    }
}