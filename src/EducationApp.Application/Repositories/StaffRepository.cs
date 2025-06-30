using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public class StaffRepository(EduDbContext context) : Repository<Staff>(context), IStaffRepository
{
}
