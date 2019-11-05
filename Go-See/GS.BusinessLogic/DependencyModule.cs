using Autofac;
using GS.BusinessLogic.Contracts;

namespace GS.BusinessLogic
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}