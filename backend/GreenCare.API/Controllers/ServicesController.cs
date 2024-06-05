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
    }
}
