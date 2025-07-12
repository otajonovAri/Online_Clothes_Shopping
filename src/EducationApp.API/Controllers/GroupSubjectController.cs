using EducationApp.Application.DTOs.GroupSubjectDto;
using EducationApp.Application.Service.GroupSubjectServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupSubjectController(IGroupSubjectService service) : ControllerBase
{
    [HttpGet("get-all-groupsubject")]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAllAsync());

    [HttpGet("get-by-id-groupsubject/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await service.GetByIdAsync(id);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }

    [HttpPost("create-groupsubject")]
    public async Task<IActionResult> Create([FromBody] GroupSubjectCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.CreateAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result);
        //return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
    }

    [HttpPut("update-groupsubject-by-id/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] GroupSubjectUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.UpdateAsync(id, dto);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }

    [HttpDelete("delete-groupsubject-by-id/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteAsync(id);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }
}
