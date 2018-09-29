using Autofac;

namespace Gunnsoft.Api.Authentication
{
    public static class ClientIdExtensions
    {
        public static ContainerBuilder AddClaimsClientIdAccessor
        (
            this ContainerBuilder extended
        )
        {
            extended.RegisterType<ClaimsClientIdAccessor>()
                .As<IClientIdAccessor>()
                .InstancePerLifetimeScope();

            return extended;
        }

        public static ContainerBuilder AddHeaderClientIdAccessor
        (
            this ContainerBuilder extended
        )
        {
            extended.RegisterType<HeaderClientIdAccessor>()
                .As<IClientIdAccessor>()
                .InstancePerLifetimeScope();

            return extended;
        }
    }
}
