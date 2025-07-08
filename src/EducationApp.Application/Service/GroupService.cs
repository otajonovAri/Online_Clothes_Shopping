using AutoMapper;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;

namespace EducationApp.Application.Service;

public class GroupService(IGroupRepository repo , IMapper mapper) : IGroupService
{
    public Task<ApiResult<List<GroupDto>>> GetAllAsync()
    {
        var groups = repo.GetAll().ToList();
        var dto = mapper.Map<List<GroupDto>>(groups);

        return Task.FromResult(new ApiResult<List<GroupDto>>("Success", true, dto));
    }

    public async Task<ApiResult<GroupDto>> GetByIdAsync(int id)
    {
        var group = await repo.GetByIdAsync(id);
        if (group is null)
            return new ApiResult<GroupDto>("Group not found", false, null!);

        var dto = mapper.Map<GroupDto>(group);
        return new ApiResult<GroupDto>("Success", true, dto);
    }

    public async Task<ApiResult<string>> CreateAsync(GroupDto dto)
    {
        var entity = mapper.Map<Group>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();

        return new ApiResult<string>("Group created successfully", true, "Created");
    }

    public async Task<ApiResult<string>> UpdateAsync(int id, GroupDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        
        if (existing == null)
            return new ApiResult<string>("Group not found", false, null!);

        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<string>("Group Update successfully", true, "Update");
    }

    public async Task<ApiResult<string>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);

        if (existing == null)
            return new ApiResult<string>("Group not found", false, null!);

        repo.Delete(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<string>("Group deleted successfully", true, "Deleted");
    }
}