using EducationApp.Application.Repositories.Interfaces;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public class FileRepository(EduDbContext context) : Repository<Core.Entities.File>(context), IFileRepository
{
}
