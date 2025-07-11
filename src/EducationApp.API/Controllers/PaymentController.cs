using EducationApp.Application.DTOs.PaymentDto;
using EducationApp.Application.Service.PaymentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController(IPaymentService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetAllAsync();
        return Ok(result);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await service.GetByIdAsync(id);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PaymentCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.CreateAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
        /*
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);*/
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PaymentUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        payment.StudentId = dto.StudentId;
        payment.Amount = dto.Amount;
        payment.PaymentDate = dto.PaymentDate;
        payment.PaymentType = dto.PaymentType;
        payment.Note = dto.Note;

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteAsync(id);
        if (!result.Success)
            return NotFound(result.Message);
        return Ok(result);
    }
}
