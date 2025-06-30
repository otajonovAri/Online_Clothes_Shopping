using EducationApp.Application.Repositories;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.DataAccess.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.Application.DIcontainer;

public static class DependencyInjection
{
    public static IServiceCollection ServiceContainer(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IGroupRepository , GroupRepository>();

        services.AddScoped<IGroupRoomRepository , GroupRoomRepository>();

        services.AddScoped<IGroupSubjectRepository , GroupSubjectRepository>();

        services.AddScoped<IPaymentRepository , PaymentRepository>();

        services.AddScoped<IStudentRepository , StudentRepository>();

        services.AddScoped<ISubjectRepository , SubjectRepository>();

        return services;
    }
}
