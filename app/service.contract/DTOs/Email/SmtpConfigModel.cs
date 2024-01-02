namespace service.contract.DTOs.Email
{
    public class SmtpConfigModel
    {
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public bool UseSsl { get; set; }
    }
}
