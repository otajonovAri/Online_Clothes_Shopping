using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EducationApp.Application.Models;
using EducationApp.Application.Models.Dtos;

namespace EducationApp.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginDto);
        Task<ApiResult<string>> RegisterAsync(string firstname, string lastname, string email, string password, bool isadminSite);
    }
}
