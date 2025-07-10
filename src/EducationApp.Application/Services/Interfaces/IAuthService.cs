using EducationApp.Application.Models;
using EducationApp.Application.Models.Dtos;

namespace EducationApp.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginDto);
        Task<ApiResult<string>> RegisterAsync(RegisterRequestDto requestDto);
    }
}
