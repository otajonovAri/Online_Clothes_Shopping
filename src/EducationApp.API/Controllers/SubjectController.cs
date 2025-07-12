using EducationApp.Application.DTOs.GroupSubjectDto;
using EducationApp.Application.DTOs.SubjectDto;
using EducationApp.Application.Service.SubjectServices;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController(ISubjectService service) : ControllerBase
{
    [HttpGet("get-all-subject")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await service.GetAllAsync());

    [HttpGet("get-by-id-subject/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await service.GetByIdAsync(id);

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost("create-subject")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSubjectDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.CreateAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result);
    }

    [HttpPut("update-subject-by-id/{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] SubjectUpdateDto dto , int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await service.UpdateAsync(id, dto);

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete("delete-subject-by-id/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await service.DeleteAsync(id);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }
}
