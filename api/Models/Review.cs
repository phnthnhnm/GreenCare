using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
    }
}
