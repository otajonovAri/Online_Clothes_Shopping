using AutoMapper;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Core.DTOs;

namespace EducationApp.Application.Service;

public class StaffSubjectService(IMapper mapper , IStaffSubjectRepository repo) : IStaffSubjectService
{
    public Task<ApiResult<List<StaffSubjectDto>>> GetAll()
    {
        var staffSubject = repo.GetAll().ToList();
        var dto = mapper.Map<List<StaffSubjectDto>>(staffSubject);

        return Task.FromResult(new ApiResult<List<StaffSubjectDto>>("Success", true, dto));
    }

    public async Task<ApiResult<StaffSubjectDto>> GetByIdAsync(int id)
    {
       var staffSubject = await repo.GetByIdAsync(id);
        if (staffSubject is null)
            return new ApiResult<StaffSubjectDto>("Staff Subject not found", false, null!);
        var dto = mapper.Map<StaffSubjectDto>(staffSubject);
        return new ApiResult<StaffSubjectDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(StaffSubjectDto dto)
    {
        var entity = mapper.Map<Core.Entities.StaffSubject>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Staff Subject created successfully", true, "Created");
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, StaffSubjectDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        
        if (existing == null)
            return new ApiResult<object>("Staff Subject not found", false, null!);
        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Staff Subject updated successfully", true, "Updated");
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing == null)
            return new ApiResult<object>("Staff Subject not found", false, null!);
        repo.Delete(existing);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Staff Subject deleted successfully", true, "Deleted");
    }

    /*
     * Get By Condition is not implemented in the original code.
     */

    public Task<ApiResult<object>> GetByCondition(string query)
    {
        throw new NotImplementedException();
    }
}