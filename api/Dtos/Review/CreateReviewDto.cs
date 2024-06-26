using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Review
{
    public class CreateReviewDto
    {
        public string UserId { get; set; }

        public int ServiceId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
    }
}
