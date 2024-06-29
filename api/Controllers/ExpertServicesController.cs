using api.Dtos.ExpertServices;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/expert-services")]
    public class ExpertServicesController : ControllerBase
    {
        private readonly IExpertServicesRepository _expertServiceRepo;
        private readonly IAccountsRepository _accountsRepo;

        public ExpertServicesController(IExpertServicesRepository expertServiceRepo, IAccountsRepository accountsRepo)
        {
            _expertServiceRepo = expertServiceRepo;
            _accountsRepo = accountsRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expertServices = await _expertServiceRepo.GetAllAsync();
            var expertServicesDto = expertServices.Select(es => es.ToExpertServiceDto());

            return Ok(expertServicesDto);
        }

        [HttpGet("expert")]
        [Authorize(Roles = "Expert")]
        public async Task<IActionResult> GetExpertServices()
        {
            var userEmail = User.GetUserEmail();
            var user = await _accountsRepo.GetUserByEmailAsync(userEmail);
            var expertServices = await _expertServiceRepo.GetServicesByExpertAsync(user);
            var expertServicesDto = expertServices.Select(es => es.ToServiceDto());

            return Ok(expertServicesDto);
        }

        [HttpGet("{serviceId}/experts")]
        public async Task<IActionResult> GetExpertsByServiceId(int serviceId)
        {
            var experts = await _expertServiceRepo.GetExpertsByServiceAsync(serviceId);
            var expertDtos = experts.Select(e => e.ToAccountDto());

            return Ok(expertDtos);
        }

        [HttpGet("{expertId}/services")]
        public async Task<IActionResult> GetServicesByExpertId(string expertId)
        {
            var services = await _expertServiceRepo.GetServicesByExpertIdAsync(expertId);
            var serviceDtos = services.Select(s => s.ToServiceDto());

            return Ok(serviceDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpertServiceDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expertService = createDto.ToExpertServiceFromCreateDto();
            await _expertServiceRepo.CreateAsync(expertService);

            return Ok();
        }

        [HttpDelete("{expertId}/{serviceId}")]
        public async Task<IActionResult> Delete(string expertId, int serviceId)
        {
            await _expertServiceRepo.DeleteAsync(expertId, serviceId);

            return Ok();
        }
    }
}
