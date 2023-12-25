using domain;
using domain.shared.Attributes;
using domain.shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace service.contract.DTOs.Account
{
    public class AccountDTO : AppEntityDefaultKeyDTO
    {
        public string Username { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        [PhoneNumber]
        public string? Phone { get; set; }
        public string? Img { get; set; }
        public Role Role { get; set; }
    }
}
