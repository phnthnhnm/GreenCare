namespace api.Dtos.Account
{
    public class RegisterResultDto
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
