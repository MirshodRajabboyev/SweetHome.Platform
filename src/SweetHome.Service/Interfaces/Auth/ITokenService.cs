using SweetHome.Domain.Entities.Users;

namespace SweetHome.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);

}
