using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service.Interface;

public interface IUserService
{
    Task<ApiResult<List<UserDto>>> GetAllAsync();
    Task<ApiResult<UserDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(UserDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, UserDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
    Task<ApiResult<object>> GetByUserGender();
}