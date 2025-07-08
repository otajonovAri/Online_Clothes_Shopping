using AutoMapper;
using AutoMapper.QueryableExtensions;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Service;

public class RoomService(IRoomRepository repo , IMapper mapper) : IRoomService
{
    public Task<ApiResult<List<RoomDto>>> GetAllRoom()
    {
        var rooms = repo.GetAll().ToList();

        var dto = mapper.Map<List<RoomDto>>(rooms);

        return Task.FromResult(new ApiResult<List<RoomDto>>("Success", true, dto));
    }

    public async Task<ApiResult<RoomDto>> GetByIdAsync(int id)
    {
        var room = await repo.GetByIdAsync(id);

        if (room is null)
            return new ApiResult<RoomDto>("Room Not Found", false, null!);

        var dto = mapper.Map<RoomDto>(room);

        return new ApiResult<RoomDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(RoomDto dto)
    {
        var entity = mapper.Map<Room>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Room Created SuccessFully", true, entity);
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, RoomDto dto)
    {
        var existing = await repo.GetByIdAsync(id);

        if (existing is null)
            return new ApiResult<object>("Room Not Found", false, null!);

        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();

        var entity = await repo.GetByIdAsync(id);

        return new ApiResult<object>("Room Update", true, entity);
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);

        if (existing == null)
            return new ApiResult<object>("Room Not Found", false, null!);

        repo.Delete(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Room deleted successfully", true, $"{existing.Id}");
    }

    public async Task<ApiResult<object>> GetByCondition(string inputQuery)
    {
        var outputQuery = await repo.GetByCondition(x => x.RoomName == inputQuery)
            .ProjectTo<RoomDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new ApiResult<object>("Success", true, outputQuery);
    }
}