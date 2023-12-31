using domain.shared.Attributes;
using domain.shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Account
{
    public class AccountNoPasswordDTO : AppEntityDefaultKeyDTO
    {
        public string Username { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        [PhoneNumber]
        public string? Phone { get; set; }
        public string? Img { get; set; }
        public Role Role { get; set; }
    }
}
