using GreenCare.API.Models;

namespace GreenCare.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}
