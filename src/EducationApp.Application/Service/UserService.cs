using AutoMapper;
using AutoMapper.QueryableExtensions;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using EducationApp.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Service;

public class UserService(IUserRepository repo, IMapper mapper) : IUserService
{
    public Task<ApiResult<List<UserDto>>> GetAllAsync()
    {
        var users = repo.GetAll().ToList();
        var dto = mapper.Map<List<UserDto>>(users);
        return Task.FromResult(new ApiResult<List<UserDto>>("Success", true, dto));
    }

    public async Task<ApiResult<UserDto>> GetByIdAsync(int id)
    {
        var user = await repo.GetByIdAsync(id);
        if (user is null)
            return new ApiResult<UserDto>("User not found", false, null!);
        var dto = mapper.Map<UserDto>(user);
        return new ApiResult<UserDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(UserDto dto)
    {
        var entity = mapper.Map<User>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("User created successfully", true, "Created");
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, UserDto dto)
    {
        var existing = await repo.GetByIdAsync(id);

        if (existing == null)
            return new ApiResult<object>("User not found", false, null!);

        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("User updated successfully", true, "Updated");
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);

        if (existing == null)
            return new ApiResult<object>("User not found", false, null!);

        repo.Delete(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("User deleted successfully", true, "Deleted");
    }


    public async Task<ApiResult<object>> GetByUserGender()
    {
        var query = await repo.GetByCondition(x => x.Gender == Gender.Female)
            .ProjectTo<UserDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new ApiResult<object>("Success", true, query);
    }
}
