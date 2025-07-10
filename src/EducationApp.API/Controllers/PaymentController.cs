using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController(IPaymentRepository repo) : ControllerBase
{
    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var payments = repo.GetAll();
        return Ok(payments);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var payment = await repo.GetByIdAsync(id);
        if (payment is null)
            return NotFound($"Payment with ID {id} not found.");

        return Ok(payment);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PaymentDto dto)
    {
        var payment = new Payment
        {
            StudentId = dto.StudentId,
            Amount = dto.Amount,
            PaymentDate = dto.PaymentDate,
            PaymentType = dto.PaymentType,
        };

        await repo.AddAsync(payment);
        await repo.SaveChangesAsync();

        return Ok(payment.Id);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PaymentDto dto)
    {
        var payment = await repo.GetByIdAsync(id);
        if (payment is null)
            return NotFound($"Payment with ID {id} not found.");

        payment.StudentId = dto.StudentId;
        payment.Amount = dto.Amount;
        payment.PaymentDate = dto.PaymentDate;
        payment.PaymentType = dto.PaymentType;

        repo.Update(payment);
        await repo.SaveChangesAsync();

        return Ok("Updated successfully.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var payment = await repo.GetByIdAsync(id);
        if (payment is null)
            return NotFound($"Payment with ID {id} not found.");

        repo.Delete(payment);
        await repo.SaveChangesAsync();

        return Ok("Deleted successfully.");
    }
}
