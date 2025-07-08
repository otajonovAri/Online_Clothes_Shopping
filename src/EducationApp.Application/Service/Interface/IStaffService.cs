using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service.Interface;

public interface IStaffService
{
    Task<ApiResult<List<StaffDto>>> GetAll();
    Task<ApiResult<StaffDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(StaffDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, StaffDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
    Task<ApiResult<object>> GetByCondition(string query);
}