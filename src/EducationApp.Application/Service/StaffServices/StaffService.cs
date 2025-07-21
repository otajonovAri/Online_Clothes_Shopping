﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using EducationApp.Application.DTOs.StaffDto;
using EducationApp.Application.Helpers.PasswordHasher;
using EducationApp.Application.Repositories.StaffRepository;
using EducationApp.Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Service.StaffServices;

public class StaffService(IStaffRepository repo, IMapper mapper) : IStaffService
{
    public async Task<ApiResult<List<StaffResponseDto>>> GetAllAsync()
    {
        var staffList = await repo.GetAll()
            .ProjectTo<StaffResponseDto>(mapper.ConfigurationProvider).ToListAsync();

        return new ApiResult<List<StaffResponseDto>>("Success", true, staffList);
    }

    public async Task<ApiResult<StaffResponseDto>> GetByIdAsync(int id)
    {
        var staff = await repo.GetByIdAsync(id);
        
        if (staff is null)
            return new ApiResult<StaffResponseDto>("Staff not Found", false, null!);
        
        var dto = mapper.Map<StaffResponseDto>(staff);
        return new ApiResult<StaffResponseDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(StaffCreateDto dto)
    {
        var entity = mapper.Map<Core.Entities.Staff>(dto);
        var passwordHasher = new PasswordHasher();
        var solt = passwordHasher.GenerateSalt();
        entity.PasswordHash = passwordHasher.Encrypt(dto.Password, solt);
        entity.PasswordSolt = solt;
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Staff Created", true, $"{entity.Id}");
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, StaffUpdateDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        
        if (existing is null)
            return new ApiResult<object>("Staff not Found", false, null!);
        
        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();
        
        return new ApiResult<object>("Staff Update SuccessFully", true, $"{existing.Id}");
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);
        
        if (existing is null)
            return new ApiResult<object>("Staff not Found", false, null!);
        
        repo.Delete(existing);
        await repo.SaveChangesAsync();
        
        return new ApiResult<object>("Staff Deleted SuccessFully", true, $"{existing.Id}");
    }
}