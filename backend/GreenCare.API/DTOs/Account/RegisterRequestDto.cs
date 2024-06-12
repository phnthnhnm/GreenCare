using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.DTOs.Account
{
    public class RegisterRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } // Insecure, for example only

        [Required]
        public string Role { get; set; } // Make sure you validate this against allowed roles

        [Required]
        public string Name { get; set; }

        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
