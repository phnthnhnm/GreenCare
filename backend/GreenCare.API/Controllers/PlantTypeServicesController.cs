using GreenCare.API.Dtos.PlantTypeService;
using GreenCare.API.Interfaces;
using GreenCare.API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GreenCare.API.Controllers
{
    [ApiController]
    [Route("api/plant-type-services")]
    public class PlantTypeServicesController : ControllerBase
    {
        private readonly IPlantTypeRepository _plantTypeRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IPlantTypeServiceRepository _plantTypeServiceRepo;

        public PlantTypeServicesController(IPlantTypeRepository plantTypeRepo, IServiceRepository serviceRepo, IPlantTypeServiceRepository plantTypeServiceRepo)
        {
            _plantTypeRepo = plantTypeRepo;
            _serviceRepo = serviceRepo;
            _plantTypeServiceRepo = plantTypeServiceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var plantTypeServices = await _plantTypeServiceRepo.GetAllAsync();

            var plantTypeServiceDtos = plantTypeServices.Select(pts => pts.ToPlantTypeServiceDto());

            return Ok(plantTypeServiceDtos);
        }

        [HttpGet("{plantTypeId}/services")]
        public async Task<IActionResult> GetServicesByPlantTypeId(int plantTypeId)
        {
            var services = await _plantTypeServiceRepo.GetServicesByPlantTypeIdAsync(plantTypeId);

            var serviceDtos = services.Select(s => s.ToServiceDto());

            return Ok(serviceDtos);
        }

        [HttpGet("{serviceId}/plant-types")]
        public async Task<IActionResult> GetPlantTypesByServiceId(int serviceId)
        {
            var plantTypes = await _plantTypeServiceRepo.GetPlantTypesByServiceIdAsync(serviceId);

            var plantTypeDtos = plantTypes.Select(pt => pt.ToPlantTypeDto());

            return Ok(plantTypeDtos);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlantTypeServiceDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantTypeService = createDto.ToPlantTypeServiceFromCreateDto();

            await _plantTypeServiceRepo.AddAsync(plantTypeService);

            return Ok();
        }

        [HttpDelete("{plantTypeId}/{serviceId}")]
        public async Task<IActionResult> Delete(int plantTypeId, int serviceId)
        {
            await _plantTypeServiceRepo.DeleteAsync(plantTypeId, serviceId);

            return Ok();
        }
    }
}
