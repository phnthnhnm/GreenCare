using api.Dtos.PlantType;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/plant-types")]
    public class PlantTypesController : ControllerBase
    {
        private readonly IPlantTypesRepository _plantTypeRepo;

        public PlantTypesController(IPlantTypesRepository plantTypeRepo)
        {
            _plantTypeRepo = plantTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PlantTypeQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantTypes = await _plantTypeRepo.GetAllAsync(query);
            var plantTypeDto = plantTypes.Select(pt => pt.ToPlantTypeDto());

            return Ok(plantTypeDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantType = await _plantTypeRepo.GetByIdAsync(id);

            if (plantType == null)
            {
                return NotFound();
            }

            return Ok(plantType.ToPlantTypeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlantTypeDto plantTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantType = plantTypeDto.ToPlantTypeFromCreateDto();
            await _plantTypeRepo.CreateAsync(plantType);
            return CreatedAtAction(nameof(GetById), new { id = plantType.Id }, plantType.ToPlantTypeDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePlantTypeDto plantTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantTypeModel = await _plantTypeRepo.UpdateAsync(id, plantTypeDto);

            if (plantTypeModel == null)
            {
                return NotFound();
            }

            return Ok(plantTypeModel.ToPlantTypeDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantTypeModel = await _plantTypeRepo.DeleteAsync(id);

            if (plantTypeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
