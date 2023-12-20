using domain;

namespace service.contract.DTOs.Account
{
    public class AccountDTO : AppEntityDefaultKey
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
