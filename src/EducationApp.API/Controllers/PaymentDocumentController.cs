using EducationApp.Application.Auth;
using EducationApp.Application.DTOs.PaymentDocumentDto;
using EducationApp.Application.Service.PaymentDocumentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentDocumentController(IPaymentDocumentService service) : ControllerBase
{
    [HttpGet("get-all-paymentdocument")]
    [HttpGet]
    [PermissionAuthorize(Core.Permission.GetAllPaymentDocumentPermission)]
    public async Task<IActionResult> GetAllAsync()
    => Ok(await service.GetAllAsync());

    [HttpGet("get-by-id-paymentdocument/{id}")]
    [HttpGet("{id}")]
    [PermissionAuthorize(Core.Permission.GetByIdPaymentDocumentPermission)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await service.GetByIdAsync(id);
        if(!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost("create-paymentdocument")]
    [HttpPost]
    [PermissionAuthorize(Core.Permission.CreatePaymentDocumentPermission)]
    public async Task<IActionResult> CreateAsync([FromBody] PaymentDocumentCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.CreateAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result);
    }

    [HttpPut("update-paymentdocument-by-id/{id}")]
    [HttpPut("{id}")]
    [PermissionAuthorize(Core.Permission.UpdatePaymentDocumentPermission)]
    public async Task<IActionResult> UpdateAsync(int id ,[FromBody] PaymentDocumentUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await service.UpdateAsync(id, dto);

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete("delete-paymentdocument-by-id/{id}")]
    [HttpDelete("{id}")]
    [PermissionAuthorize(Core.Permission.DeletePaymentDocumentPermission)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await service.DeleteAsync(id);
        
        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
