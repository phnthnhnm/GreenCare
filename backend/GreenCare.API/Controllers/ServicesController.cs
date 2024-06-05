using GreenCare.API.Data;
using GreenCare.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly GreenCareDbContext _context;

        public ServicesController(GreenCareDbContext context)
        {
            _context = context;
        }

        [HttpGet] // This attribute defines the action as a GET request
        public async Task<ActionResult<IEnumerable<Service>>> GetAllServices()
        {
            try
            {
                // Fetch all services from the database, including related PlantType and Expert data
                var services = await _context.Services
                    .Include(s => s.PlantType)
                    .Include(s => s.Expert)
                    .ToListAsync();

                return Ok(services); // Return services with a 200 OK status
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine(ex.Message);

                // Return a generic error message for security reasons
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
