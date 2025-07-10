using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;

namespace EducationApp.Application.Services.Interfaces;

public interface IPermissionService
{
	Task CreateAsync(PermissionDto dto);
	List<Permission> GetAll();
}
