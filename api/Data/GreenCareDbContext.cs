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
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<PlantTypeService> PlantTypeServices { get; set; }
        public virtual DbSet<ExpertService> ExpertServices { get; set; }


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

            builder.Entity<ExpertService>().HasKey(es => new { es.ExpertId, es.ServiceId });

            builder.Entity<ExpertService>()
                .HasOne(es => es.Expert)
                .WithMany(e => e.ExpertServices)
                .HasForeignKey(es => es.ExpertId);

            builder.Entity<ExpertService>()
                .HasOne(es => es.Service)
                .WithMany(s => s.ExpertServices)
                .HasForeignKey(es => es.ServiceId);

            builder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(u => u.UserAppointments)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Expert)
                .WithMany(u => u.ExpertAppointments)
                .HasForeignKey(a => a.ExpertId)
                .OnDelete(DeleteBehavior.Restrict);

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
