using EducationApp.Core.Entities;

namespace EducationApp.Application.Repositories.Interfaces;

public interface IStaffSubjectRepository : IRepository<StaffSubject>
{
    Task<StaffSubject> GetByStaffIdAsync(int staffId);

    Task<StaffSubject> GetBySubjectIdAsync(int subjectId);

    Task<StaffSubject> GetByStaffAndSubjectId(int staffId, int subjectId);
}