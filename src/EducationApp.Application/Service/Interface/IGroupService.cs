using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service.Interface;

public interface IGroupService
{
    Task<ApiResult<List<GroupDto>>> GetAllAsync();
    Task<ApiResult<GroupDto>> GetByIdAsync(int id);
    Task<ApiResult<string>> CreateAsync(GroupDto dto);
    Task<ApiResult<string>> UpdateAsync(int id, GroupDto dto);
    Task<ApiResult<string>> DeleteAsync(int id);
}