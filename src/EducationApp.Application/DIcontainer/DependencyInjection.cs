using EducationApp.Application.Repositories;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Service;
using EducationApp.Application.Service.Interface;
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

        services.AddScoped<IRoomRepository, RoomRepository>();

        services.AddScoped<IPaymentService , PaymentService>();


        // Services
        services.AddScoped<IGroupService, GroupService>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IRoomService , RoomService>();

        services.AddScoped<IPaymentService , PaymentService>();

        services.AddScoped<IStudentService , StudentService>();

        services.AddScoped<IRoomService , RoomService>();

        services.AddScoped<IStaffService, StaffService>();

        services.AddScoped<IGroupSubjectService, GroupSubjectService>();

        services.AddScoped<IStaffSubjectService, StaffSubjectService>();

        services.AddScoped<ISubjectService, SubjectService>();

        return services;
    }
}
