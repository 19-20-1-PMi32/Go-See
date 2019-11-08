using Autofac;
using GS.DataBase.Repository;
using GS.DataBase.Repository.Contracts;

namespace GS.DataBase
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<PlaceRepository>().As<IPlaceRepository>();
            builder.RegisterType<ReviewRepository>().As<IReviewRepository>();
            builder.RegisterType<TripNodeRepository>().As<ITripNodeRepository>();
            builder.RegisterType<TripRepository>().As<ITripRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}