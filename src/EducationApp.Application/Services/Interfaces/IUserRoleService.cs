using EducationApp.Core.DTOs;

namespace EducationApp.Application.Services.Interfaces;

public  interface IUserRoleService
{
	Task AssignAsync(UserRoleDto userRoleDto);
	Task CreateAsync(PermissionDto dto);
}
