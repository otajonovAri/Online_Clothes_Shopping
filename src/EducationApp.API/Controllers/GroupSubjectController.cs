using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupSubjectController(IGroupSubjectRepository repo) : ControllerBase
{
    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var groupSubjects = repo.GetAll();
        return Ok(groupSubjects);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null)
            return NotFound($"GroupSubject with ID {id} not found");
    
        return Ok(entity);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] GroupSubjectDto dto)
    {
        var entity = new GroupSubject
        {
            GroupId = dto.GroupId,
            SubjectId = dto.SubjectId,
            StaffId = dto.StaffId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        await repo.AddAsync(entity);
        await repo.SaveChangesAsync();

        return Ok(entity.Id);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] GroupSubjectDto dto)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null)
            return NotFound($"GroupSubject with ID {id} not found");

        entity.GroupId = dto.GroupId;
        entity.SubjectId = dto.SubjectId;
        entity.StaffId = dto.StaffId;
        entity.StartDate = dto.StartDate;
        entity.EndDate = dto.EndDate;

        repo.Update(entity);
        await repo.SaveChangesAsync();

        return Ok("Updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null)
            return NotFound($"GroupSubject with ID {id} not found");

        repo.Delete(entity);
        await repo.SaveChangesAsync();

        return Ok("Deleted successfully");
    }
}
