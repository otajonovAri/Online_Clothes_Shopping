using AutoMapper;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;

namespace EducationApp.Application.Service;

public class GroupSubjectService(IGroupSubjectRepository repo , IMapper mapper) : IGroupSubjectService
{
    public Task<ApiResult<List<GroupSubjectDto>>> GetAllRoom()
    {
        var groupSubjects = repo.GetAll().ToList();
        var dto = mapper.Map<List<GroupSubjectDto>>(groupSubjects);
        return Task.FromResult(new ApiResult<List<GroupSubjectDto>>("Success", true, dto));
    }

    public async Task<ApiResult<GroupSubjectDto>> GetByIdAsync(int id)
    {
        var groupSubject = await repo.GetByIdAsync(id);

        if (groupSubject is null)
            return new ApiResult<GroupSubjectDto>("Group Subject Not Found", false, null!);

        var dto = mapper.Map<GroupSubjectDto>(groupSubject);

        return new ApiResult<GroupSubjectDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(GroupSubjectDto dto)
    {
        var entity = mapper.Map<GroupSubject>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Group Subject Created Successfully", true, entity);
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, GroupSubjectDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Group Subject Not Found", false, null!);
        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();
        var updatedEntity = await repo.GetByIdAsync(id);
        return new ApiResult<object>("Group Subject Updated Successfully", true, updatedEntity);
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Group Subject Not Found", false, null!);
        repo.Delete(existing);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Group Subject Deleted Successfully", true, null);
    }

    /*
     * Gey By Condition method is not implemented in this service.
     */

    public Task<ApiResult<object>> GetByCondition(string query)
    {
        throw new NotImplementedException();
    }
}