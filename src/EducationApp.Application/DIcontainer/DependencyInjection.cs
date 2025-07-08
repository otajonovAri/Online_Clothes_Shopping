using EducationApp.Application.Helpers.GenerateJwt;
using EducationApp.Application.Helpers.PasswordHasher;
using EducationApp.Application.Repositories;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Services.Interfaces;
using EducationApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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

        services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }

    public static IServiceCollection AddJwtOption(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOption>(configuration.GetSection("JwtOption"));
        return services;
    }

   
}
