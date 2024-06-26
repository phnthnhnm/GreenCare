namespace api.Dtos.Account
{
    public class LoginResultDto
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
