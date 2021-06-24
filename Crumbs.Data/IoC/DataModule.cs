using Crumbs.Data.UoW;
using Autofac;

namespace Crumbs.Data.IoC
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}