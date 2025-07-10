using EducationApp.Core.DTOs;

namespace EducationApp.Application.Services.Interfaces;

public interface IRoleService
{
	Task CreateAsync(RoleDto dto);
	Task AssignPermissionAsync(RolePermissionDto dto);
}
