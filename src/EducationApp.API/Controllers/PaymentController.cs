using EducationApp.Application.Service.Interface;
using EducationApp.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);

            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentDto dto)
        {
            var result = await service.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaymentDto dto)
        {
            var result = await service.UpdateAsync(id, dto);
            if (!result.Success)
                return NotFound(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);
            if (!result.Success)
                return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("BankTransfer")]
        public async Task<IActionResult> GetBankTransferPayments(string bankTransfer)
        {
            var result = await service.GetByCondition(bankTransfer);
            
            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result);
        }
    }
}
