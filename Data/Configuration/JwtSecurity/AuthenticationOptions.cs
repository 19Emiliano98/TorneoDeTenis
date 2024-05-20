namespace JwtSecurity
{
    public  class AuthenticationOptions
    { 
        public static string Section = "Application:Authentication";
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
        public int Expiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public int ExpirationToken { get; set; }
    }
}
