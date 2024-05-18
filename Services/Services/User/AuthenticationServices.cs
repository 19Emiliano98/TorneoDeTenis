using Contracts.DTO.Requests.Jwt;
using Contracts.DTO.Responses.JwtResponse;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services.Services.User
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly JwtSecurity.AuthenticationOptions _authenticationOptions;
        private readonly TournamentContext _contxt;

        public AuthenticationServices(TournamentContext contxt, JwtSecurity.AuthenticationOptions opt)
        {
            _authenticationOptions = opt;
            _contxt = contxt;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }



        public TokenResponse generateToken(Users user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            string role = "";

            if (user.Name.EndsWith("@arbitro.com"))
            {
                role = "arbitro";
            }
            else if (user.Name.EndsWith("@gmail.com"))
            {
                role = "jugador";
            }

            var claims = new List<Claim>()
            {
                new ("Id", user.Id.ToString()),
                new (JwtRegisteredClaimNames.UniqueName, user.Name),
                new ("Role", role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expDate = DateTime.UtcNow.AddMinutes(_authenticationOptions.Expiration);

            var expRefrestokenDate = DateTime.UtcNow.AddMinutes(_authenticationOptions.RefreshTokenExpiration);

            var token = new JwtSecurityToken(
                issuer: _authenticationOptions.Issuer,
                audience: _authenticationOptions.Audience,
             claims: claims,
             expires: expDate,
             signingCredentials: credentials
         );

            var rta = new TokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationToken = expDate,
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpiration = expRefrestokenDate
            };
            user.refreshToken = rta.RefreshToken;
            user.RefreshTokenExpiration = rta.RefreshTokenExpiration;

            _contxt.Update(user);
            return rta;
        }

        public bool ValidateRefreshToken(Users usuario)
        {
            return usuario.RefreshTokenExpiration > DateTime.UtcNow;
        }
        public TokenResponse RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            // Primero, busca al usuario por el token
            var user =  _contxt.Set<Users>()
                .FirstOrDefault(u => u.refreshToken == refreshTokenRequest.RefreshToken);

            // Si no se encuentra el usuario, lanza una excepción
            if (user == null)
            {
                throw new Exception("Invalid refresh token");
            }

            // Verifica si el refresh token está expirado
            if (!ValidateRefreshToken(user))
            {
                throw new Exception("Refresh token is expired");
            }

            // Si el refresh token es válido, genera un nuevo token
            return generateToken(user);
        }



    }
}
