using EducationApp.Application.Repositories.Repository;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories.UserRepository;

public class UserRepository(EduDbContext context) : Repository<User>(context), IUserRepository
{
}