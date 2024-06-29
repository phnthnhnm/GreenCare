using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PlantCareLog;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/plant-care-logs")]
    public class PlantCareLogsController : ControllerBase
    {
        private readonly IPlantCareLogsRepository _plantCareLogsRepo;
        private readonly IAccountsRepository _accountsRepo;

        public PlantCareLogsController(IPlantCareLogsRepository plantCareLogsRepo, IAccountsRepository accountsRepo)
        {
            _plantCareLogsRepo = plantCareLogsRepo;
            _accountsRepo = accountsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var plantCareLogs = await _plantCareLogsRepo.GetAllAsync();
            var plantCareLogDtos = plantCareLogs.Select(plantCareLog => plantCareLog.ToPlantCareLogDto());
            return Ok(plantCareLogDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plantCareLog = await _plantCareLogsRepo.GetByIdAsync(id);
            if (plantCareLog == null)
            {
                return NotFound();
            }
            return Ok(plantCareLog.ToPlantCareLogDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlantCareLogDto createDto)
        {
            var plantCareLog = createDto.ToPlantCareLogFromCreateDto();
            await _plantCareLogsRepo.CreateAsync(plantCareLog);
            return CreatedAtAction(nameof(GetById), new { id = plantCareLog.Id }, plantCareLog.ToPlantCareLogDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePlantCareLogDto updateDto)
        {
            var plantCareLog = await _plantCareLogsRepo.UpdateAsync(id, updateDto);
            if (plantCareLog == null)
            {
                return NotFound();
            }
            return Ok(plantCareLog.ToPlantCareLogDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var plantCareLog = await _plantCareLogsRepo.DeleteAsync(id);
            if (plantCareLog == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserPlantCareLogs()
        {
            var userEmail = User.GetUserEmail();
            var user = await _accountsRepo.GetUserByEmailAsync(userEmail);
            var plantCareLogs = await _plantCareLogsRepo.GetPlantCareLogsByUserAsync(user);
            var plantCareLogDtos = plantCareLogs.Select(plantCareLog => plantCareLog.ToPlantCareLogDto());
            return Ok(plantCareLogDtos);
        }

        [HttpGet("expert")]
        [Authorize(Roles = "Expert")]
        public async Task<IActionResult> GetExpertPlantCareLogs()
        {
            var expertEmail = User.GetUserEmail();
            var expert = await _accountsRepo.GetUserByEmailAsync(expertEmail);
            var plantCareLogs = await _plantCareLogsRepo.GetPlantCareLogsByExpertAsync(expert);
            var plantCareLogDtos = plantCareLogs.Select(plantCareLog => plantCareLog.ToPlantCareLogDto());
            return Ok(plantCareLogDtos);
        }
    }
}
