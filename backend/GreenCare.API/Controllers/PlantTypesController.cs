using GreenCare.API.Data;
using GreenCare.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<PlantType>>> GetAllPlantTypes()
        {
            try
            {
                var plantTypes = await _context.PlantTypes.ToListAsync();

                return Ok(plantTypes);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<PlantType>> GetPlantType(int id)
        {
            try
            {
                var plantType = await _context.PlantTypes.FindAsync(id);

                if (plantType == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(plantType);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("AddPlantType")] 
        public async Task<ActionResult<PlantType>> AddPlantType(PlantType newPlantType)
        {
            try
            {
                _context.PlantTypes.Add(newPlantType);

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPlantType), new { id = newPlantType.Id }, newPlantType);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("UpdatePlantType/{id}")]
        public async Task<IActionResult> UpdatePlantType(int id, PlantType updatedPlantType)
        {
            if (id != updatedPlantType.Id)
            {
                return BadRequest();
            }

            try
            {
                _context.Entry(updatedPlantType).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PlantTypes.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }

            return NoContent();
        }

        [HttpDelete("DeletePlantType/{id}")]
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
