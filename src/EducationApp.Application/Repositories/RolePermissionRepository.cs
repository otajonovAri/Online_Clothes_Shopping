using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public class RolePermissionRepository(EduDbContext context) : Repository<RolePermission>(context), IRolePermissionRepository
{
}
