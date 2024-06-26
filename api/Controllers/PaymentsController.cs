using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Payment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsRepository _paymentsRepo;

        public PaymentsController(IPaymentsRepository paymentsRepo)
        {
            _paymentsRepo = paymentsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _paymentsRepo.GetAllAsync();
            var paymentsDto = payments.Select(p => p.ToPaymentDto());
            return Ok(paymentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentsRepo.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment.ToPaymentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentDto createDto)
        {
            var payment = createDto.ToPaymentFromCreateDto();
            await _paymentsRepo.CreateAsync(payment);
            return CreatedAtAction(nameof(GetById), new { id = payment.Id }, payment.ToPaymentDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePaymentDto updateDto)
        {
            var payment = await _paymentsRepo.UpdateAsync(id, updateDto);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment.ToPaymentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _paymentsRepo.DeleteAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
