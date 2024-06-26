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
        [Authorize(Roles = "Expert")]
        public async Task<IActionResult> GetExpertServices()
        {
            var userEmail = User.GetUserEmail();
            var user = await _accountsRepo.GetUserByEmailAsync(userEmail);
            var expertServices = await _expertServiceRepo.GetExpertServicesAsync(user);
            var expertServicesDto = expertServices.Select(es => es.ToServiceDto());

            return Ok(expertServicesDto);
        }
    }
}