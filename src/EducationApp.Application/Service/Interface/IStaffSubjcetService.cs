using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Repositories.Interfaces;

public interface IStaffSubjectService
{
    Task<ApiResult<List<StaffSubjectDto>>> GetAll();
    Task<ApiResult<StaffSubjectDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(StaffSubjectDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, StaffSubjectDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
    Task<ApiResult<object>> GetByCondition(string query);
}