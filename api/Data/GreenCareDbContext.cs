using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class GreenCareDbContext : IdentityDbContext<ApplicationUser>
    {
        public GreenCareDbContext()
        {
        }

        public GreenCareDbContext(DbContextOptions<GreenCareDbContext> options) : base(options)
        {
        }

        public virtual DbSet<PlantType> PlantTypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<PlantTypeService> PlantTypeServices { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PlantTypeService>().HasKey(ps => new { ps.PlantTypeId, ps.ServiceId });

            builder.Entity<PlantTypeService>()
                .HasOne(ps => ps.PlantType)
                .WithMany(pt => pt.PlantTypeServices)
                .HasForeignKey(ps => ps.PlantTypeId);

            builder.Entity<PlantTypeService>()
                .HasOne(ps => ps.Service)
                .WithMany(s => s.PlantTypeServices)
                .HasForeignKey(ps => ps.ServiceId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" },
                new IdentityRole { Name = "Expert", NormalizedName = "EXPERT" }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
