using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service.Interface;

public interface IStudentService
{
    Task<ApiResult<List<StudentDto>>> GetAll();
    Task<ApiResult<StudentDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(StudentDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, StudentDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
    Task<ApiResult<object>> GetByCondition(string query);
}