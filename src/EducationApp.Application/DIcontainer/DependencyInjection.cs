using EducationApp.DataAccess.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.Application.DIcontainer;

public static class DependencyInjection
{
    public static IServiceCollection ServiceContainer(this IServiceCollection services)
    {
        return services;
    }
}
