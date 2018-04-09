using Autofac;

namespace Gunnsoft.Api.Authentication
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddClaimsSubAccessor(this ContainerBuilder extended)
        {
            extended.RegisterType<ClaimsSubAccessor>()
                .As<ISubAccessor>()
                .InstancePerLifetimeScope();

            return extended;
        }

        public static ContainerBuilder AddHeaderSubAccessor(this ContainerBuilder extended)
        {
            extended.RegisterType<HeaderSubAccessor>()
                .As<ISubAccessor>()
                .InstancePerLifetimeScope();

            return extended;
        }
    }
}