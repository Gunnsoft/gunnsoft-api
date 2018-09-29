using Autofac;

namespace Gunnsoft.Api.Authentication
{
    public static class SubjectExtensions
    {
        public static ContainerBuilder AddClaimsSubAccessor
        (
            this ContainerBuilder extended
        )
        {
            extended.RegisterType<ClaimsSubjectAccessor>()
                .As<ISubjectAccessor>()
                .InstancePerLifetimeScope();

            return extended;
        }

        public static ContainerBuilder AddHeaderSubAccessor
        (
            this ContainerBuilder extended
        )
        {
            extended.RegisterType<HeaderSubjectAccessor>()
                .As<ISubjectAccessor>()
                .InstancePerLifetimeScope();

            return extended;
        }
    }
}