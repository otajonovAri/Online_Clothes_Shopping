﻿using EducationApp.Application.DTOs.GroupDto;
using EducationApp.Application.Responses;

namespace EducationApp.Application.Service.GroupServices;

public interface IGroupService
{
    Task<ApiResult<List<GroupResponseDto>>> GetAllAsync();
    Task<ApiResult<GroupResponseDto>> GetByIdAsync(int id);
    Task<ApiResult<object>> CreateAsync(GroupCreatedDto dto);
    Task<ApiResult<object>> UpdateAsync(int id, GroupUpdateDto dto);
    Task<ApiResult<object>> DeleteAsync(int id);
}