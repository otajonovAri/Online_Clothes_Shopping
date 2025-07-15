using EducationApp.Application.DTOs.StaffDto;
using EducationApp.Application.DTOs.StudentDto;
using EducationApp.Application.Responses;

namespace EducationApp.Application.Service.StaffServices;

public interface IStaffService
{
    Task<ApiResult<List<StaffResponseDto>>> GetAllAsync();
    Task<ApiResult<StaffResponseDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(StaffCreateDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, StaffUpdateDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
}