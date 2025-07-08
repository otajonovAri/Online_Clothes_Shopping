using AutoMapper;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Service;

public class StudentService(IStudentRepository repo , IMapper mapper) : IStudentService
{
    public Task<ApiResult<List<StudentDto>>> GetAll()
    {
        var students = repo.GetAll().ToList();
        var dto = mapper.Map<List<StudentDto>>(students);
        return Task.FromResult(new ApiResult<List<StudentDto>>("Success", true, dto));
    }

    public async Task<ApiResult<StudentDto>> GetByIdAsync(int id)
    {
       var student = await repo.GetByIdAsync(id);
        
        if (student is null)
            return new ApiResult<StudentDto>("Student not found", false, null!);
        
        var dto = mapper.Map<StudentDto>(student);
        return new ApiResult<StudentDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(StudentDto dto)
    {
        var entity = mapper.Map<Student>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Student created successfully", true, entity);
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, StudentDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Student not found", false, null!);
        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();
        return new ApiResult<object>("Student updated successfully", true, $"{existing.FirstName}");
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null)
            return new ApiResult<object>("Studnet not found", false, null!);

        repo.Delete(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Student deleted successfully", true, $"{existing.FirstName}");
    }

    public async Task<ApiResult<object>> GetByCondition(string query)
    {
        var outputQuery = await repo
            .GetByCondition(x => x.FirstName.ToLower() == query.ToLower() || x.LastName == query.ToLower())
            .ToListAsync();

        return new ApiResult<object>("Success", true, outputQuery);
    }
}