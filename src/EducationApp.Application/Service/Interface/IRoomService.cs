using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service.Interface;

public interface IRoomService
{
    Task<ApiResult<List<RoomDto>>> GetAllRoom();
    Task<ApiResult<RoomDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(RoomDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, RoomDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
    Task<ApiResult<object>> GetByCondition(string query);
}