using AutoMapper;
using AutoMapper.QueryableExtensions;
using EducationApp.Application.DTOs.GroupDto;
using EducationApp.Application.Repositories.GroupRepository;
using EducationApp.Application.Responses;
using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Service.GroupServices;

public class GroupService(IGroupRepository repo , IMapper mapper) : IGroupService
{
    public async Task<ApiResult<List<GroupResponseDto>>> GetAllAsync()
    {   
        var groups = await repo.GetAll()
            .ProjectTo<GroupResponseDto>(mapper.ConfigurationProvider).ToListAsync();

        return new ApiResult<List<GroupResponseDto>>("Success", true, groups);
    }

    public async Task<ApiResult<GroupResponseDto>> GetByIdAsync(int id)
    {
        var group = await repo.GetByIdAsync(id);

        if(group is null)
            return new ApiResult<GroupResponseDto>("Group not Found", false, null!);

        var dto = mapper.Map<GroupResponseDto>(group);

        return new ApiResult<GroupResponseDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(GroupCreatedDto dto)
    {
        var entity = mapper.Map<Group>(dto);
        
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Group Created", true, $"{entity.Id}");
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, GroupUpdateDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Group not Found", false, null!);
        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Group Update SuccessFully", true, $"{existing.Id}");
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);

        if (existing is null)
            return new ApiResult<object>("Group not found", false, null!);

        repo.Delete(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Group Deleted Successfully", true, $"{existing.Id}");
    }

    public async Task<int> GetByConditionGroupCount()
    {
        var groupCount = await repo.GetByCondition(g => true).CountAsync();
        return groupCount;
    }
}