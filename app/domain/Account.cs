using domain.shared.Attributes;
using domain.shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class Account : AppEntityDefaultKey
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string? Phone { get; set; }
        public string? Img { get; set; }
        public Role Role { get; set; }
    }
}
