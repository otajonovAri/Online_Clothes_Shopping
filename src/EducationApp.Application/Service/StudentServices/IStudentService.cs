using EducationApp.Application.DTOs.StudentDto;
using EducationApp.Application.DTOs.UserDto;
using EducationApp.Application.Responses;

namespace EducationApp.Application.Service.StudentServices;

public interface IStudentService
{
    Task<ApiResult<List<StudentResponseDto>>> GetAllAsync();
    Task<ApiResult<StudentResponseDto>> GetByIdAsync(int id);
    Task<int> GetCountOfActiveStudents();
    Task<int> GetCountOfUnpaidStudents();
    Task<int> GetCountOfPaidStudentsOnThisMonth();
    Task<int> GetCountOfGraduatedStudents();
    Task<ApiResult<object>> CreateAsync(StudentCreateDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, StudentUpdateDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
}