using Microsoft.Extensions.DependencyInjection;
using Libraries.Abstractions.Contracts;
using Scrutor;

namespace Libraries.Abstractions;

public static class Extensions
{
    public static void AddApplicationsAsScoped(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromApplicationDependencies()
                .AddClasses(c => c.AssignableTo<IApplication>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithTransientLifetime()
        );
    }

    public static void AddDomainsAsScoped(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromApplicationDependencies()
                .AddClasses(c => c.AssignableTo<IDomain>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithTransientLifetime()
        );
    }
}