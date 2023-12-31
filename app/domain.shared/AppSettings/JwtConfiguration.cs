namespace domain.shared.AppSettings
{
    public class JwtConfiguration
    {
        public string Key { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public int ValidTime { get; set; }
        public int RefreshTokenValidTime { get; set; }
        public string HashSalt { get; set; } = null!;
    }
}
