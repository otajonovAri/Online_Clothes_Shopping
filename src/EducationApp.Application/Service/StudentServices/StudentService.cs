using AutoMapper;
using AutoMapper.QueryableExtensions;
using EducationApp.Application.DTOs.StudentDto;
using EducationApp.Application.Repositories.StudentRepository;
using EducationApp.Application.Responses;
using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Service.StudentServices;

public class StudentService(IStudentRepository repo , IMapper mapper) : IStudentService
{
    public async Task<ApiResult<List<StudentResponseDto>>> GetAllAsync()
    {
        var students = await repo
            .GetAll()
            .ProjectTo<StudentResponseDto>(mapper.ConfigurationProvider).ToListAsync();

        return new ApiResult<List<StudentResponseDto>>("Success", true, students);
    }

    public async Task<ApiResult<StudentResponseDto>> GetByIdAsync(int id)
    {
        var student = await repo.GetByIdAsync(id);
        
        if (student is null)
            return new ApiResult<StudentResponseDto>("Student not Found", false, null!);
        
        var dto = mapper.Map<StudentResponseDto>(student);

        return new ApiResult<StudentResponseDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(StudentCreateDto dto)
    {
        var entity = mapper.Map<Student>(dto);

        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Student Created", true, $"{entity.Id}");
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, StudentUpdateDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        
        if (existing is null)
            return new ApiResult<object>("Student not Found", false, null!);
        
        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Student Update SuccessFully", true, $"{existing.Id}");
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);
        
        if (existing is null)
            return new ApiResult<object>("Student not Found", false, null!);
        
        repo.Delete(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Student Deleted SuccessFully", true, $"{existing.Id}");
    }
}