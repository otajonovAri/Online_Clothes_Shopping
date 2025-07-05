using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController(IGroupRepository repo) : ControllerBase
{
    [HttpGet("get-all-groups")]
    public IActionResult GetAllGroups()
    {
        var groups = repo.GetAll();
        return Ok(groups);
    }
    
    [HttpGet("get-group-by-id/{id}")]
    public async Task<IActionResult> GetGroupById([FromRoute] int id)
    {
        var group = await repo.GetByIdAsync(id);
        if (group == null)
            return NotFound($"Group with ID {id} not found");

        return Ok(group);
    }
    
    [HttpPost("create-group")]
    public async Task<IActionResult> CreateGroup([FromBody] GroupDto dto)
    {
        var group = new Group
        {
            Name = dto.Name,
            SubjectId = dto.SubjectId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Schedule = dto.Schedule
        };

        await repo.AddAsync(group);
        await repo.SaveChangesAsync();

        return Ok(group.Id);
    }
    
    [HttpPut("update-group/{id}")]
    public async Task<IActionResult> UpdateGroup([FromRoute] int id, [FromBody] GroupDto dto)
    {
        var group = await repo.GetByIdAsync(id);
        if (group == null)
            return NotFound($"Group with ID {id} not found");

        group.Name = dto.Name;
        group.SubjectId = dto.SubjectId;
        group.StartDate = dto.StartDate;
        group.EndDate = dto.EndDate;
        group.Schedule = dto.Schedule;

        repo.Update(group);
        await repo.SaveChangesAsync();

        return Ok("Group updated successfully");
    }

    [HttpDelete("delete-group/{id}")]
    public async Task<IActionResult> DeleteGroup([FromRoute] int id)
    {
        var group = await repo.GetByIdAsync(id);
        if (group == null)
            return NotFound($"Group with ID {id} not found");

        repo.Delete(group);
        await repo.SaveChangesAsync();

        return Ok("Group deleted successfully");
    }
}
