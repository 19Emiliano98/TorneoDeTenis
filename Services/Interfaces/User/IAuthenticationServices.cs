using Contracts.DTO.Requests.Jwt;
using Contracts.DTO.Responses.JwtResponse;
using Data.Entities;

namespace Services.Interfaces.User
{
    public interface IAuthenticationServices
    {
        TokenResponse GenerateToken(Users user);
        string GenerateRefreshToken();
        TokenResponse RefreshToken(RefreshTokenRequest refreshTokenRequest);
    }
}
