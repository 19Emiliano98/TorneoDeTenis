using Contracts.DTO.Responses.JwtResponse;
using Data.Entities;
using Data.Repository;
using JwtSecurity;
using Microsoft.AspNetCore.Authentication;
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
        // por que me da ambiguedad 
        private readonly JwtSecurity.AuthenticationOptions _authenticationOptions;
        private readonly TournamentContext _contxt;

        public AuthenticationServices(TournamentContext contxt, JwtSecurity.AuthenticationOptions opt)
        {
            _authenticationOptions = opt;
            _contxt = contxt;
        }

        private string GenerateRefreshToken()
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

            return new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationToken = expDate,
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpiration = expRefrestokenDate
            };
        }

        public bool ValidateRefreshToken(Users usuario)
        {
            return usuario.RefreshTokenExpiration > DateTime.UtcNow;
        }

        public async Task UpdateRefreshToken(Users userFromDB, string refreshToken)
        {
            userFromDB.refreshToken = refreshToken;
            userFromDB.RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(_authenticationOptions.RefreshTokenExpiration);

            _contxt.Update(userFromDB);
            await _contxt.SaveChangesAsync();
        }
    }
}
