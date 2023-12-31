namespace domain.shared.AppSettings
{
    public class MailConfiguration
    {
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public bool UseSsl { get; set; }
    }
}
