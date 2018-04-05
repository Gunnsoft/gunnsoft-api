using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

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

        public static ContainerBuilder AddHeadersSubAccessor(this ContainerBuilder extended)
        {
            extended.RegisterType<HeaderSubAccessor>()
                .As<ISubAccessor>()
                .InstancePerLifetimeScope();

            return extended;
        }
    }
}