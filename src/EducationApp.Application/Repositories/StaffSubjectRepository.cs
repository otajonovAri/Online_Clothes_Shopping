using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Repositories;

public class StaffSubjectRepository(EduDbContext context) : Repository<StaffSubject>(context), IStaffSubjectRepository
{
    public async Task<StaffSubject> GetByStaffAndSubjectId(int staffId, int subjectId)
    {
        return await context.StaffSubjects
            .FirstOrDefaultAsync(ss => ss.StaffId == staffId && ss.SubjectId == subjectId);
    }

    public async Task<StaffSubject> GetByStaffIdAsync(int staffId)
    {
        return await context.StaffSubjects
            .FirstOrDefaultAsync(ss => ss.StaffId == staffId);
    }

    public async Task<StaffSubject> GetBySubjectIdAsync(int subjectId)
    {
        return await context.StaffSubjects
            .FirstOrDefaultAsync(ss => ss.SubjectId == subjectId);
    }
}