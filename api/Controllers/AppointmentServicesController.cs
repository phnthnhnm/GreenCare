using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.AppointmentService;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/appointment-services")]
    public class AppointmentServicesController : ControllerBase
    {
        private readonly IAppointmentServicesRepository _appointmentServicesRepo;

        public AppointmentServicesController(IAppointmentServicesRepository appointmentServicesRepo)
        {
            _appointmentServicesRepo = appointmentServicesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointmentServices = await _appointmentServicesRepo.GetAllAsync();
            var appointmentServiceDtos = appointmentServices.Select(aps => aps.ToAppointmentServiceDto());
            return Ok(appointmentServiceDtos);
        }

        [HttpGet("services/{appointmentId}")]
        public async Task<IActionResult> GetServicesByAppointmentId(int appointmentId)
        {
            var services = await _appointmentServicesRepo.GetServicesByAppointmentIdAsync(appointmentId);
            var serviceDtos = services.Select(s => s.ToServiceDto());
            return Ok(serviceDtos);
        }

        [HttpGet("appointments/{serviceId}")]
        public async Task<IActionResult> GetAppointmentsByServiceId(int serviceId)
        {
            var appointments = await _appointmentServicesRepo.GetAppointmentsByServiceIdAsync(serviceId);
            var appointmentDtos = appointments.Select(a => a.ToAppointmentDto());
            return Ok(appointmentDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentServiceDto createDto)
        {
            var appointmentService = createDto.ToAppointmentServiceFromCreateDto();
            await _appointmentServicesRepo.AddAsync(appointmentService);
            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpDelete("{appointmentId}/{serviceId}")]
        public async Task<IActionResult> Delete(int appointmentId, int serviceId)
        {
            await _appointmentServicesRepo.DeleteAsync(appointmentId, serviceId);
            return NoContent();
        }

    }
}
