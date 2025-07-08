using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public class GroupRepository(EduDbContext context) : Repository<Group>(context), IGroupRepository
{
}