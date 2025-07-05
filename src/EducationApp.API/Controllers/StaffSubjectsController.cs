using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffSubjectsController(IStaffSubjectRepository staffSubjectRepository) : ControllerBase
{
    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var staffSubjects = staffSubjectRepository.GetAll();

        return Ok(staffSubjects);
    }

    [HttpGet("get-by-staffId/{id}")]
    public async Task<IActionResult> GetByStaffId([FromRoute] int id)
    {
        var staffSubject = await staffSubjectRepository.GetByStaffIdAsync(id);

        if (staffSubject == null)
        {
            return NotFound();
        }

        return Ok(staffSubject);
    }

    [HttpGet("get-by-subjectId/{id}")]
    public async Task<IActionResult> GetBySubjectId([FromRoute] int id)
    {
        var staffSubject = await staffSubjectRepository.GetBySubjectIdAsync(id);

        if (staffSubject == null)
        {
            return NotFound();
        }

        return Ok(staffSubject);
    }

    [HttpGet("get-by-staff-and-subject-id/{staffId}/{subjectId}")]
    public async Task<IActionResult> GetByStaffAndSubjectId([FromRoute] int staffId, [FromRoute] int subjectId)
    {
        var staffSubject = await staffSubjectRepository.GetByStaffAndSubjectId(staffId, subjectId);

        if (staffSubject == null)
        {
            return NotFound();
        }

        return Ok(staffSubject);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] StaffSubjectDto staffSubjectDto)
    {
        if (staffSubjectDto == null)
        {
            return BadRequest("StaffSubjectDto cannot be null.");
        }

        var staffSubject = new StaffSubject
        {
            StaffId = staffSubjectDto.StaffId,
            SubjectId = staffSubjectDto.SubjectId
        };

        await staffSubjectRepository.AddAsync(staffSubject);
        await staffSubjectRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetByStaffAndSubjectId), new { staffId = staffSubject.StaffId, subjectId = staffSubject.SubjectId }, staffSubject);
    }

    [HttpDelete("delete/{staffId}")]
    public async Task<IActionResult> Delete([FromRoute] int staffId)
    {
        var staffSubject = await staffSubjectRepository.GetByStaffIdAsync(staffId);
        if (staffSubject == null)
        {
            return NotFound();
        }
        staffSubjectRepository.Delete(staffSubject);
        await staffSubjectRepository.SaveChangesAsync();
        return Ok("Deleted successfully.");
    }

    [HttpDelete("delete-by-subject-id/{subjectId}")]
    public async Task<IActionResult> DeleteBySubjectId([FromRoute] int subjectId)
    {
        var staffSubject = await staffSubjectRepository.GetBySubjectIdAsync(subjectId);
        if (staffSubject == null)
        {
            return NotFound();
        }
        staffSubjectRepository.Delete(staffSubject);
        await staffSubjectRepository.SaveChangesAsync();
        return Ok("Deleted successfully.");
    }

    [HttpDelete("delete-by-staff-and-subject-id/{staffId}/{subjectId}")]
    public async Task<IActionResult> DeleteByStaffAndSubjectId([FromRoute] int staffId, [FromRoute] int subjectId)
    {
        var staffSubject = await staffSubjectRepository.GetByStaffAndSubjectId(staffId, subjectId);
        if (staffSubject == null)
        {
            return NotFound();
        }
        staffSubjectRepository.Delete(staffSubject);
        await staffSubjectRepository.SaveChangesAsync();
        return Ok("Deleted successfully.");
    }
}
