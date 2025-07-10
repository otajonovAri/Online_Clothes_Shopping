using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController(ISubjectRepository repo) : ControllerBase
{
    [HttpGet("get-all-subjects")]
    public async Task<IActionResult> GetAllSubjects()
    {
        return Ok(repo.GetAll());
    }
    [HttpGet("get-subject-by-id/{id}")]
    public async Task<IActionResult> GetSubjectById([FromRoute] int id)
    {
        return Ok(await repo.GetByIdAsync(id));
    }

    [HttpPost("create-subject")]
    public async Task<IActionResult> CreateSubject([FromBody] SubjectDto dto)
    {
        var subject = new Subject
        {
            Name = dto.Name,
            Description = dto.Description,
            StaffId = dto.StaffId,
        };

        await repo.AddAsync(subject);
        await repo.SaveChangesAsync();

        return Ok(subject.Id);
    }

    [HttpPut("update-subject-by-id/{id}")]
    public async Task<IActionResult> UpdateSubjectById([FromRoute] int id, [FromBody] SubjectDto dto)
    {
        if (id == null)
            return NotFound("Subject Not Found!");

        var subject = new Subject
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            StaffId = dto.StaffId,
        };

        repo.Update(subject);
        await repo.SaveChangesAsync();

        return Ok("updated successfully!");
    }

    [HttpDelete("delete-subject-by-id/{id}")]
    public async Task<IActionResult> DeleteSubjectById([FromRoute] int id)
    {
        if (id == null)
            return NotFound("Subject Not Found!");

        var subject = await repo.GetByIdAsync(id);
        repo.Delete(subject);
        await repo.SaveChangesAsync();
        return Ok("Deleted Successfully!");
    }
}
