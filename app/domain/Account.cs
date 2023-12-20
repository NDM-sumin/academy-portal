namespace domain
{
    public class Account : AppEntityDefaultKey
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
