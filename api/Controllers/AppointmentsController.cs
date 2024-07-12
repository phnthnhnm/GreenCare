using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Appointment;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsRepository _appointmentsRepo;
        private readonly IAccountsRepository _accountsRepo;

        public AppointmentsController(IAppointmentsRepository appointmentsRepo, IAccountsRepository accountsRepo)
        {
            _appointmentsRepo = appointmentsRepo;
            _accountsRepo = accountsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _appointmentsRepo.GetAllAsync();
            var appointmentDtos = appointments.Select(a => a.ToAppointmentDto());

            return Ok(appointmentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _appointmentsRepo.GetByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment.ToAppointmentDto());
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var appointments = await _appointmentsRepo.GetAppointmentsByUserIdAsync(userId);
            var appointmentDtos = appointments.Select(a => a.ToAppointmentDto());

            return Ok(appointmentDtos);
        }

        [HttpGet("expert/{expertId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByExpertId(string expertId)
        {
            var appointments = await _appointmentsRepo.GetAppointmentsByExpertIdAsync(expertId);
            var appointmentDtos = appointments.Select(a => a.ToAppointmentDto());

            return Ok(appointmentDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appointment = appointmentDto.ToAppointmentFromCreateDto();

            await _appointmentsRepo.CreateAsync(appointment);

            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment.ToAppointmentDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedAppointment = await _appointmentsRepo.UpdateAsync(id, appointmentDto);

            if (updatedAppointment == null)
            {
                return NotFound();
            }

            return Ok(updatedAppointment.ToAppointmentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentsRepo.DeleteAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserAppointments()
        {
            var userEmail = User.GetUserEmail();
            var user = await _accountsRepo.GetUserByEmailAsync(userEmail);
            var appointments = await _appointmentsRepo.GetAppointmentsByUserAsync(user);
            var appointmentDtos = appointments.Select(a => a.ToAppointmentDto());

            return Ok(appointmentDtos);
        }

        [HttpGet("expert")]
        [Authorize(Roles = "Expert")]
        public async Task<IActionResult> GetExpertAppointments()
        {
            var expertEmail = User.GetUserEmail();
            var expert = await _accountsRepo.GetUserByEmailAsync(expertEmail);
            var appointments = await _appointmentsRepo.GetAppointmentsByExpertAsync(expert);
            var appointmentDtos = appointments.Select(a => a.ToAppointmentDto());

            return Ok(appointmentDtos);
        }
    }
}
