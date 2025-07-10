using EducationApp.Core.DTOs;

namespace EducationApp.Application.Services.Interfaces;

public interface IPermissionService
{
	Task CreateAsync(PermissionDto dto);
}
