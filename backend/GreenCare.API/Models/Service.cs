using System.ComponentModel.DataAnnotations.Schema;

namespace GreenCare.API.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(150)")]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public int Duration { get; set; }

        public List<PlantTypeService> PlantTypeServices { get; set; } = new List<PlantTypeService>();

        // [Required]
        // public int PlantTypeId { get; set; }

        // [Required]
        // public int? ExpertId { get; set; }

        // public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        // public virtual ApplicationUser? Expert { get; set; }

        // public virtual ICollection<PlantType> PlantTypes { get; set; } = new List<PlantType>();

        // public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
