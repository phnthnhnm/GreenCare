using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Appointment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsRepository _appointmentsRepo;

        public AppointmentsController(IAppointmentsRepository appointmentsRepo)
        {
            _appointmentsRepo = appointmentsRepo;
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
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var appointments = await _appointmentsRepo.GetAppointmentsByUserIdAsync(userId);
            var appointmentDtos = appointments.Select(a => a.ToAppointmentDto());

            return Ok(appointmentDtos);
        }

        [HttpGet("expert/{expertId}")]
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
    }
}
