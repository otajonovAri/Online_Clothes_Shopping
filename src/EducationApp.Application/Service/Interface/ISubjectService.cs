using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service.Interface;

public interface ISubjectService
{
    Task<ApiResult<List<SubjectDto>>> GetAll();
    Task<ApiResult<SubjectDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(SubjectDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, SubjectDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
    Task<ApiResult<object>> GetByCondition(string query);
}