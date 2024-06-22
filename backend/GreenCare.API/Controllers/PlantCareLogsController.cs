using GreenCare.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantCareLogsController : ControllerBase
    {
        private readonly GreenCareDbContext _context;

        public PlantCareLogsController(GreenCareDbContext context)
        {
            _context = context;
        }

        // GET: api/PlantCareLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantCareLog>>> GetPlantCareLogs()
        {
            return await _context.PlantCareLogs.ToListAsync();
        }

        // GET: api/PlantCareLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantCareLog>> GetPlantCareLog(int id)
        {
            var plantCareLog = await _context.PlantCareLogs.FindAsync(id);

            if (plantCareLog == null)
            {
                return NotFound();
            }

            return plantCareLog;
        }

        // PUT: api/PlantCareLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantCareLog(int id, PlantCareLog plantCareLog)
        {
            if (id != plantCareLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantCareLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantCareLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlantCareLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlantCareLog>> PostPlantCareLog(PlantCareLog plantCareLog)
        {
            _context.PlantCareLogs.Add(plantCareLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantCareLog", new { id = plantCareLog.Id }, plantCareLog);
        }

        // DELETE: api/PlantCareLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantCareLog(int id)
        {
            var plantCareLog = await _context.PlantCareLogs.FindAsync(id);
            if (plantCareLog == null)
            {
                return NotFound();
            }

            _context.PlantCareLogs.Remove(plantCareLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantCareLogExists(int id)
        {
            return _context.PlantCareLogs.Any(e => e.Id == id);
        }
    }
}
