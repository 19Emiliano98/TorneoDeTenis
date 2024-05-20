namespace Contracts.DTO.Requests.Jwt
{
    public  class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
