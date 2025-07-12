using EducationApp.Core;
using EducationApp.Application.DTOs.AttendanceDto;
using EducationApp.Application.Service.AttendanceServices;
using Microsoft.AspNetCore.Mvc;
using EducationApp.Application.Auth;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendanceController(IAttendanceService service) : ControllerBase
{
    [HttpGet]
    [PermissionAuthorize(Permission.GetAllAttendancePermission)]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await service.GetAllAsync());

    [HttpGet("{id}")]
    [PermissionAuthorize(Permission.GetByIdAttendancePermission)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await service.GetByIdAsync(id);
        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [PermissionAuthorize(Permission.CreateAttendancePermission)]
    public async Task<IActionResult> CreateAsync([FromBody] AttendanceCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.CreateAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result);
    }

    [HttpPut("{id}")]
    [PermissionAuthorize(Permission.UpdateAttendancePermission)]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] AttendanceUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await service.UpdateAsync(id, dto);

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [PermissionAuthorize(Permission.DeleteAttendancePermission)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await service.DeleteAsync(id);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }
}
