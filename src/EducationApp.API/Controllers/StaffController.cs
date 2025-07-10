using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController(IStaffRepository repo) : ControllerBase
{
    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var staffs = repo.GetAll();
        return Ok(staffs);
    }
    
    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var staff = await repo.GetByIdAsync(id);
        if (staff is null)
            return NotFound($"Staff with ID {id} not found.");

        return Ok(staff);
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] StaffDto dto)
    {
        var staff = new Staff
        {
            UserId = dto.UserId,
            FullName = dto.FullName,
            Position = dto.Position,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            Salary = dto.Salary
        };

        await repo.AddAsync(staff);
        await repo.SaveChangesAsync();

        return Ok(staff.Id);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StaffDto dto)
    {
        var staff = await repo.GetByIdAsync(id);
        if (staff is null)
            return NotFound($"Staff with ID {id} not found.");

        staff.UserId = dto.UserId;
        staff.FullName = dto.FullName;
        staff.Position = dto.Position;
        staff.PhoneNumber = dto.PhoneNumber;
        staff.Address = dto.Address;
        staff.BirthDate = dto.BirthDate;
        staff.Gender = dto.Gender;
        staff.Salary = dto.Salary;

        repo.Update(staff);
        await repo.SaveChangesAsync();

        return Ok("Updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var staff = await repo.GetByIdAsync(id);
        if (staff is null)
            return NotFound($"Staff with ID {id} not found.");

        repo.Delete(staff);
        await repo.SaveChangesAsync();

        return Ok("Deleted successfully");
    }
}
