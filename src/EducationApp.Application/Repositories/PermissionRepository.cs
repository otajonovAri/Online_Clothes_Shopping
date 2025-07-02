using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public class PermissionRepository(EduDbContext context) : Repository<Permission>(context), IPermissionRepository
{
}
