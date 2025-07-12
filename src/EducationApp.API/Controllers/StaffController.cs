using EducationApp.Application.Auth;
using EducationApp.Application.DTOs.StaffDto;
using EducationApp.Application.Service.StaffServices;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController(IStaffService service) : ControllerBase
{
    [HttpGet]
    [PermissionAuthorize(Core.Permission.GetAllStaffPermission)]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAllAsync());

    [HttpGet("{id:int}")]
    [PermissionAuthorize(Core.Permission.GetByIdStaffPermission)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await service.GetByIdAsync(id);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }

    [HttpPost]
    [PermissionAuthorize(Core.Permission.CreateStaffPermission)]
    public async Task<IActionResult> Create([FromBody] StaffCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.CreateAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result);
        //return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
    }

    [HttpPut("{id:int}")]
    [PermissionAuthorize(Core.Permission.UpdateStaffPermission)]
    public async Task<IActionResult> Update(int id, [FromBody] StaffUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.UpdateAsync(id, dto);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    [PermissionAuthorize(Core.Permission.DeleteStaffPermission)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteAsync(id);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }
}
