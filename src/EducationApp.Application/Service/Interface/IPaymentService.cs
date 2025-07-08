using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service.Interface;

public interface IPaymentService
{
    Task<ApiResult<List<PaymentDto>>> GetAll();
    Task<ApiResult<PaymentDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(PaymentDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, PaymentDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
    Task<ApiResult<object>> GetByCondition(string query);
}