namespace GreenCare.API.DTOs.Account
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }

        // Option 1: Include only counts of related items
        public int AppointmentsAsCustomerCount { get; set; }
        public int AppointmentsAsExpertCount { get; set; }
        public int PlantCareLogCount { get; set; }
        public int ReviewCount { get; set; }
        public int ServiceCount { get; set; }

    }
}
