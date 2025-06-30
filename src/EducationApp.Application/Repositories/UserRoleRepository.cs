using EducationApp.Application.Entities;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public class UserRoleRepository(EduDbContext context) : Repository<UserRole>(context), IUserRoleRepository
{
}
