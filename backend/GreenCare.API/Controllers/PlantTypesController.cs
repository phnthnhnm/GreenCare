using GreenCare.API.Data;
using GreenCare.API.Entities;
using GreenCare.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace GreenCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantTypesController : ControllerBase
    {
        private readonly GreenCareDbContext _context;

        public PlantTypesController(GreenCareDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantTypeDto>>> GetAllPlantTypes()
        {
            try
            {
                var plantTypes = await _context.PlantTypes
                    .Include(pt => pt.Services)
                    .ToListAsync();

                // Map PlantType entities to DTOs
                var plantTypeDtos = plantTypes.Select(pt => new PlantTypeDto
                {
                    Id = pt.Id,
                    Name = pt.Name,
                    ServiceCount = pt.Services.Count
                }).ToList();

                return Ok(plantTypeDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error."); // Generic error message
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantTypeDto>> GetPlantType(int id)
        {
            try
            {
                var plantType = await _context.PlantTypes
                    .Include(pt => pt.Services)
                    .FirstOrDefaultAsync(pt => pt.Id == id);

                if (plantType == null)
                {
                    return NotFound(new { Message = "Plant type not found." }); // Consistent error format
                }

                var plantTypeDto = new PlantTypeDto
                {
                    Id = plantType.Id,
                    Name = plantType.Name,
                    ServiceCount = plantType.Services.Count
                };

                return Ok(plantTypeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpPost]
        public async Task<ActionResult<PlantTypeDto>> AddPlantType([FromBody] AddPlantTypeDto addPlantTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (await _context.PlantTypes.AnyAsync(pt => pt.Name == addPlantTypeDto.Name))
                {
                    return Conflict("This plant type already exists.");
                }

                var newPlantType = new PlantType
                {
                    Name = addPlantTypeDto.Name,
                };

                _context.PlantTypes.Add(newPlantType);
                await _context.SaveChangesAsync();

                // Map to DTO before returning
                var plantTypeDto = new PlantTypeDto
                {
                    Id = newPlantType.Id,
                    Name = newPlantType.Name,
                    ServiceCount = newPlantType.Services.Count
                };

                return CreatedAtAction(nameof(GetPlantType), new { id = newPlantType.Id }, plantTypeDto);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "An error occurred while creating the plant type.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlantType(int id, [FromBody] UpdatePlantTypeDto updatedPlantTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingPlantType = await _context.PlantTypes.FindAsync(id);
                if (existingPlantType == null)
                {
                    return NotFound(new { Message = "Plant type not found." });
                }

                // Check for duplicate name (case-insensitive)
                if (await _context.PlantTypes.AnyAsync(pt =>
                    pt.Name.ToLower() == updatedPlantTypeDto.Name.ToLower() && pt.Id != id))
                {
                    return Conflict(new { Message = "Plant type with this name already exists." });
                }

                // Update the existing entity with values from the DTO
                existingPlantType.Name = updatedPlantTypeDto.Name;
                // Update other properties as needed

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PlantTypes.Any(p => p.Id == id))
                {
                    return NotFound(new { Message = "Plant type not found." });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the plant type.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantType(int id)
        {
            try
            {
                var plantType = await _context.PlantTypes.FindAsync(id);
                if (plantType == null)
                {
                    return NotFound();
                }

                _context.PlantTypes.Remove(plantType);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine(ex.Message);

                return Conflict("Cannot delete plant type due to existing dependencies.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
