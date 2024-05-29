using Microsoft.EntityFrameworkCore;

namespace GreenCare.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Entities.Account> Accounts { get; set; }
    }
}
