using Autofac;
using GS.DataBase.Repository;
using GS.DataBase.Repository.Contracts;

namespace GS.DataBase
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ICityRepository>().As<CityRepository>();
            builder.RegisterType<IPlaceRepository>().As<PlaceRepository>();
            builder.RegisterType<IReviewRepository>().As<ReviewRepository>();
            builder.RegisterType<ITripNodeRepository>().As<TripNodeRepository>();
            builder.RegisterType<ITripRepository>().As<TripRepository>();
            builder.RegisterType<IUserRepository>().As<UserRepository>();

            builder.RegisterType<IUnitOfWork>().As<UnitOfWork>();
        }
    }
}