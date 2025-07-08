using AutoMapper;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;

namespace EducationApp.Application.Service;

public class SubjectService(ISubjectRepository repo , IMapper mapper) : ISubjectService
{
    public Task<ApiResult<List<SubjectDto>>> GetAll()
    {
        var subjects = repo.GetAll();
        var dto = mapper.Map<List<SubjectDto>>(subjects);

        return Task.FromResult(new ApiResult<List<SubjectDto>>("Success", true, dto));
    }

    public async Task<ApiResult<SubjectDto>> GetByIdAsync(int id)
    {
        var subject = await repo.GetByIdAsync(id);

        if (subject is null)
            return new ApiResult<SubjectDto>("success", true, null!);

        var dto = mapper.Map<SubjectDto>(subject);

        return new ApiResult<SubjectDto>("Success", true, dto);
    }

    public async Task<ApiResult<object>> CreateAsync(SubjectDto dto)
    {
        var entity = mapper.Map<Subject>(dto);
        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Group created successfully", true, entity);
    }

    public async Task<ApiResult<object>> UpdateAsync(int id, SubjectDto dto)
    {
        var existing = await repo.GetByIdAsync(id);

        if (existing is null)
            return new ApiResult<object>("Payment Not Found", false, null!);

        mapper.Map(dto, existing);
        repo.Update(existing);
        await repo.SaveChangesAsync();


        return new ApiResult<object>("Subject update SuccessFully", true, existing);
    }

    public async Task<ApiResult<object>> DeleteAsync(int id)
    {
        var existing = await repo.GetByIdAsync(id);

        if (existing is null)
            return new ApiResult<object>("Success", false, null!);

        repo.Delete(existing);
        await repo.SaveChangesAsync();

        return new ApiResult<object>("Subject Deleted Success", true, existing);
    }

    /*
     * Get By Condition Logick
     */
    public Task<ApiResult<object>> GetByCondition(string query)
    {
        throw new NotImplementedException();
    }
}