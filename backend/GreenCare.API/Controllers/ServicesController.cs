using GreenCare.API.Data;
using GreenCare.API.Entities;
using GreenCare.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly GreenCareDbContext _context;

        public ServicesController(GreenCareDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServices()
        {
            try
            {
                var services = await _context.Services
                    .Include(s => s.PlantType)   // Include PlantType for mapping
                    .Include(s => s.Expert)     // Include Expert for mapping
                    .ToListAsync();

                var serviceDtos = services.Select(service => new ServiceDto
                {
                    Id = service.Id,
                    Name = service.Name,
                    Description = service.Description,
                    Price = service.Price,
                    PlantTypeId = service.PlantTypeId,
                    PlantTypeName = service.PlantType?.Name,
                    ExpertId = service.ExpertId,
                    ExpertName = service.Expert?.Name
                }).ToList();

                return Ok(serviceDtos);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            var service = await _context.Services
                .Include(s => s.PlantType)
                .Include(s => s.Expert)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (service == null) return NotFound();

            var serviceDto = new ServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                PlantTypeId = service.PlantTypeId,
                PlantTypeName = service.PlantType?.Name, // Safely get the name
                ExpertId = service.ExpertId,
                ExpertName = service.Expert?.Name // Safely get the name
            };

            return serviceDto;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDto>> AddService([FromBody] AddServiceDto addServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (await _context.Services.AnyAsync(s => s.Name == addServiceDto.Name))
                {
                    return Conflict("This service already exists.");
                }

                var newService = new Service
                {
                    Name = addServiceDto.Name,
                    Description = addServiceDto.Description,
                    Price = addServiceDto.Price,
                    PlantTypeId = addServiceDto.PlantTypeId,
                    ExpertId = addServiceDto.ExpertId
                };

                _context.Services.Add(newService);
                await _context.SaveChangesAsync();

                // Map to DTO before returning
                var serviceDto = new ServiceDto
                {
                    Id = newService.Id,
                    Name = newService.Name,
                    Description = newService.Description,
                    Price = newService.Price,
                    PlantTypeId = newService.PlantTypeId,
                    PlantTypeName = newService.PlantType?.Name,
                    ExpertId = newService.ExpertId,
                    ExpertName = newService.Expert?.Name,
                };

                return CreatedAtAction(nameof(GetService), new { id = newService.Id }, serviceDto);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "An error occurred while creating the service.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingService = await _context.Services
                    .Include(s => s.PlantType)
                    .Include(s => s.Expert)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (existingService == null)
                {
                    return NotFound(new { Message = "Service not found." });
                }

                // Check for duplicate name
                if (await _context.Services.AnyAsync(s => s.Name.ToLower() == updateServiceDto.Name.ToLower() && s.Id != id))
                {
                    return Conflict(new { Message = "Service with this name already exists." });
                }

                // Update the service
                existingService.Name = updateServiceDto.Name;
                existingService.Description = updateServiceDto.Description;
                existingService.Price = updateServiceDto.Price;
                existingService.PlantTypeId = updateServiceDto.PlantTypeId;
                existingService.ExpertId = updateServiceDto.ExpertId;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Services.Any(s => s.Id == id))
                {
                    return NotFound(new { Message = "Service not found." });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the service.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            try
            {
                var service = await _context.Services.FindAsync(id);
                if (service == null)
                {
                    return NotFound();
                }

                _context.Services.Remove(service);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine(ex.Message);

                return Conflict("Cannot delete service due to existing dependencies.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
