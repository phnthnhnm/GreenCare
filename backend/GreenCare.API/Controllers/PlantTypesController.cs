using GreenCare.API.DTOs;
using GreenCare.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantTypesController : ControllerBase
    {
        private readonly IPlantTypeService _plantTypeService;

        public PlantTypesController(IPlantTypeService plantTypeService)
        {
            _plantTypeService = plantTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantTypeDto>>> GetPlantTypes()
        {
            try
            {
                var plantTypes = await _plantTypeService.GetAllPlantTypesAsync();
                return Ok(plantTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantTypeDto>> GetPlantType(int id)
        {
            try
            {
                var plantType = await _plantTypeService.GetPlantTypeByIdAsync(id);
                if (plantType == null)
                {
                    return NotFound(new { Message = "Plant type not found." });
                }
                return Ok(plantType);
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
                var plantType = await _plantTypeService.AddPlantTypeAsync(addPlantTypeDto);
                return CreatedAtAction(nameof(GetPlantType), new { id = plantType.Id }, plantType);
            }
            catch (DbUpdateException ex)
            {
                return Conflict("Plant type with this name already exists.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlantType(int id, [FromBody] UpdatePlantTypeDto updatePlantTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _plantTypeService.UpdatePlantTypeAsync(id, updatePlantTypeDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Plant type not found." });
            }
            catch (DbUpdateException)
            {
                return Conflict(new { Message = "Plant type with this name already exists." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantType(int id)
        {
            try
            {
                await _plantTypeService.DeletePlantTypeAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex) // Catch specific exception for dependencies
            {
                return Conflict(ex.Message); // Return the error message from the exception
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
