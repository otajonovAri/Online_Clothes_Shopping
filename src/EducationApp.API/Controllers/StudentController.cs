using EducationApp.Application.DTOs.StudentDto;
using EducationApp.Application.Responses;
using EducationApp.Application.Service.StudentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await service.GetByIdAsync(id);

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] StudentCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.CreateAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result);
        //return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Data }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] StudentUpdateDto dto)
    {
        var student = await repo.GetByIdAsync(id);
        if (student == null)
            return NotFound($"Student with id {id} not found");

        student.UserId = dto.UserId;
        student.FirstName = dto.FirstName;
        student.LastName = dto.LastName;
        student.Address = dto.Address;
        student.Status = dto.Status;
        student.JoinDate = dto.JoinDate;
        student.Note = dto.Note;

        repo.Update(student);
        await repo.SaveChangesAsync();

        return Ok("Updated successfully");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await service.DeleteAsync(id);

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
