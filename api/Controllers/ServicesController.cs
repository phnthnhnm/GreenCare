using api.Dtos.Service;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesRepository _serviceRepo;

        public ServicesController(IServicesRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _serviceRepo.GetAllAsync();

            var serviceDtos = services.Select(s => s.ToServiceDto());

            return Ok(serviceDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _serviceRepo.GetByIdAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service.ToServiceDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = serviceDto.ToServiceFromCreateDto();

            await _serviceRepo.CreateAsync(service);

            return CreatedAtAction(nameof(GetById), new { id = service.Id }, service.ToServiceDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedService = await _serviceRepo.UpdateAsync(id, serviceDto);

            if (updatedService == null)
            {
                return NotFound();
            }

            return Ok(updatedService.ToServiceDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedService = await _serviceRepo.DeleteAsync(id);

            if (deletedService == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
