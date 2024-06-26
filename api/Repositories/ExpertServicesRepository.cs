using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ExpertServicesRepository : IExpertServicesRepository
    {
        private readonly GreenCareDbContext _context;

        public ExpertServicesRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetExpertServicesAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return await _context.ExpertServices
                .Where(es => es.ExpertId == user.Id)
                .Select(es => es.Service)
                .ToListAsync();
        }
    }
}
