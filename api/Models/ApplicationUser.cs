using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FirstName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(150)")]
        public string LastName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(150)")]
        public string? Address { get; set; }

        public List<ExpertService> ExpertServices { get; set; } = new List<ExpertService>();

        // public virtual ICollection<Appointment> CustomerAppointments { get; set; } = new List<Appointment>();

        // public virtual ICollection<Appointment> ExpertAppointments { get; set; } = new List<Appointment>();

        // public virtual ICollection<PlantCareLog> PlantCareLogs { get; set; } = new List<PlantCareLog>();

        // public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        // public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
