using System.Security.Claims;

namespace api.Helpers
{
    public static class ClaimsExtensions
    {
        public static string GetUserEmail(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            var emailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email || c.Type == "email");

            if (emailClaim == null)
            {
                throw new InvalidOperationException("Email claim not found for the user.");
            }

            return emailClaim.Value;
        }
    }
}
