using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using EducationApp.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserRepository repo) : ControllerBase
{
    [HttpGet("get-all-users")]
    public IActionResult GetAllUsers()
    {
        return Ok(repo.GetAll());
    }
    
    [HttpGet("get-user-by-id/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await repo.GetByIdAsync(id);
        if (user is null)
            return NotFound($"User with ID {id} not found");

        return Ok(user);
    }
    
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
    {
        if (!Enum.TryParse<Gender>(dto.Gender, true, out var gender))
            return BadRequest("Invalid gender value. Use: Male or Female");

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Password = dto.Password,
            BirthDate = dto.BirthDate,
            Gender = gender
        };

        await repo.AddAsync(user);
        await repo.SaveChangesAsync();

        return Ok(user.Id);
    }
    
    [HttpPut("update-user/{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto dto)
    {
        var user = await repo.GetByIdAsync(id);
        if (user is null)
            return NotFound($"User with ID {id} not found");

        if (!Enum.TryParse<Gender>(dto.Gender, true, out var gender))
            return BadRequest("Invalid gender value. Use: Male or Female");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;
        user.Email = dto.Email;
        user.Password = dto.Password;
        user.BirthDate = dto.BirthDate;
        user.Gender = gender;

        repo.Update(user);
        await repo.SaveChangesAsync();

        return Ok("User updated successfully");
    }

    [HttpDelete("delete-user/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await repo.GetByIdAsync(id);
        if (user is null)
            return NotFound($"User with ID {id} not found");

        repo.Delete(user);
        await repo.SaveChangesAsync();

        return Ok("User deleted successfully");
    }
}
