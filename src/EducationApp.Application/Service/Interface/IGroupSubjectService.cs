using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service.Interface;

public interface IGroupSubjectService
{
    Task<ApiResult<List<GroupSubjectDto>>> GetAllRoom();
    Task<ApiResult<GroupSubjectDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(GroupSubjectDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, GroupSubjectDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
    Task<ApiResult<object>> GetByCondition(string query);
}