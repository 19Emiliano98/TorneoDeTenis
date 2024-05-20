namespace Contracts.DTO.Requests.Jwt
{
    public class TokenRequest
    {
        public string RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiration { get; set; }

    }
}
