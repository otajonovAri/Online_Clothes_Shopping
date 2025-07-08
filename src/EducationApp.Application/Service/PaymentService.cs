using AutoMapper;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using EducationApp.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Service;

public class PaymentService(IPaymentRepository repo , IMapper mapper) : IPaymentService
{
    public Task<ApiResult<List<PaymentDto>>> GetAll()
    {
        var payments = repo.GetAll().ToList();
        var dto = mapper.Map<List<PaymentDto>>(payments);
        return Task.FromResult(new ApiResult<List<PaymentDto>>("Success", true, dto));
    }

    public async Task<ApiResult<PaymentDto>> GetByIdAsync(int id)
    {
        var payment = await repo.GetByIdAsync(id);
        
        if (payment is null)
            return new ApiResult<PaymentDto>("Payment not found", false, null!);
        var dto = mapper.Map<PaymentDto>(payment);

        return new ApiResult<PaymentDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(PaymentDto dto)
    {
        var entity = mapper.Map<Payment>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Payment created successfully", true, entity);
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, PaymentDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Payment not found", false, null!);
        
        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Payment updated successfully", true, $"{existing.Amount}");
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Payment not found", false, null!);

        repo.Delete(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Payment deleted successfully", true, $"{existing.Amount}");
    }

    public async Task<ApiResult<object>> GetByCondition(string query)
    {
        var outputQuery = await repo
            .GetByCondition(x => x.Description == query)
            .ToListAsync();
        
        if (outputQuery is null)
            return new ApiResult<object>("No payment found with the given condition", false, null!);
        

        return new ApiResult<object>("Success", true, outputQuery);
    }
}