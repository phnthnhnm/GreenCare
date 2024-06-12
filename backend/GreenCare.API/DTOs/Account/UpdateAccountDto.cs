using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.DTOs.Account
{
    public class UpdateAccountDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }

        // IMPORTANT: Password handling 
        public string? Password { get; set; } // Insecure, for example only
                                              // In production, DO NOT include the password directly in the DTO
                                              // Instead, consider a separate endpoint or mechanism for password changes
    }
}
