using EducationApp.Application.Entities;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public class RolePermissionRepository(EduDbContext context) : Repository<RolePermission>(context), IRolePermissionRepository
{
}
