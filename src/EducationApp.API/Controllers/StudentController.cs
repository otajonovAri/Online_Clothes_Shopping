using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentRepository repo) : ControllerBase
{
    [HttpGet("get-all-students")]
    public IActionResult GetAllStudents()
    {
        var students = repo.GetAll();
        return Ok(students);
    }
    
    [HttpGet("get-student-by-id/{id}")]
    public async Task<IActionResult> GetStudentById([FromRoute] int id)
    {
        var student = await repo.GetByIdAsync(id);
        if (student is null)
            return NotFound($"Student with id {id} not found");

        return Ok(student);
    }

    [HttpPost("create-student")]
    public async Task<IActionResult> CreateStudent([FromBody] StudentDto dto)
    {
        var student = new Student
        {
            UserId = dto.UserId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Address = dto.Address,
            Status = dto.Status,
            JoinDate = dto.JoinDate,
            Note = dto.Note,
            PasswordHas = dto.PasswordHas,
            PasswordSold = dto.PasswordSold,
            RefreshToken = dto.RefreshToken
        };

        await repo.AddAsync(student);
        await repo.SaveChangesAsync();

        return Ok(student.Id);
    }

    [HttpPut("update-student/{id}")]
    public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] StudentDto dto)
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
        student.PasswordHas = dto.PasswordHas;
        student.PasswordSold = dto.PasswordSold;
        student.RefreshToken = dto.RefreshToken;

        repo.Update(student);
        await repo.SaveChangesAsync();

        return Ok("Updated successfully");
    }

    [HttpDelete("delete-student/{id}")]
    public async Task<IActionResult> DeleteStudent([FromRoute] int id)
    {
        var student = await repo.GetByIdAsync(id);
        if (student is null)
            return NotFound($"Student with id {id} not found");

        repo.Delete(student);
        await repo.SaveChangesAsync();

        return Ok("Deleted successfully");
    }
}
