using EducationApp.Application.Repositories;
using EducationApp.Application.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.Application.DIContainer;

public static class DependencyInjection
{
    public static IServiceCollection ServiceContainer(this IServiceCollection services)
    {
        services.AddScoped<IGroupRepository , GroupRepository>();

        services.AddScoped<IGroupSubjectRepository , GroupSubjectRepository>();

        services.AddScoped<IPaymentRepository , PaymentRepository>();

        services.AddScoped<IStudentRepository , StudentRepository>();

        services.AddScoped<ISubjectRepository , SubjectRepository>();

        services.AddScoped<IUserRoleRepository , UserRoleRepository>();

        services.AddScoped<IStaffRepository , StaffRepository>();

        services.AddScoped<IUserRepository , UserRepository>();

        services.AddScoped<IRoleRepository , RoleRepository>();

        services.AddScoped<IPermissionRepository , PermissionRepository>();

        services.AddScoped<IRolePermissionRepository , RolePermissionRepository>();

        services.AddScoped<IStaffSubjectRepository, StaffSubjectRepository>();

        return services;
    }
}
