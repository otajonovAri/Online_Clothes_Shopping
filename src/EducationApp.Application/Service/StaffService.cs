using AutoMapper;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service;

public class StaffService(IStaffRepository repo , IMapper mapper) : IStaffService
{
    public Task<ApiResult<List<StaffDto>>> GetAll()
    {
        var staffList = repo.GetAll().ToList();
        var dto = mapper.Map<List<StaffDto>>(staffList);
        return Task.FromResult(new ApiResult<List<StaffDto>>("Success", true, dto));
    }

    public async Task<ApiResult<StaffDto>> GetByIdAsync(int id)
    {
       var staff = await repo.GetByIdAsync(id);
        
        if (staff is null)
            return new ApiResult<StaffDto>("Staff not found", false, null!);
        
        var dto = mapper.Map<StaffDto>(staff);
        return new ApiResult<StaffDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(StaffDto dto)
    {
        var entity = mapper.Map<Core.Entities.Staff>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Staff created successfully", true, entity);
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, StaffDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Staff not found", false, null!);
        
        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Staff updated successfully", true, $"{existing.FullName}");
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Staff not found", false, null!);
        repo.Delete(existing);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Staff deleted successfully", true, $"{existing.FullName}");
    }

    /*
     * Get By Condition is not implemented in this service.
     */

    public Task<ApiResult<object>> GetByCondition(string query)
    {
        throw new NotImplementedException();
    }
}