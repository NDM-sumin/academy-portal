using System.ComponentModel.DataAnnotations;

namespace service.contract.DTOs.Account
{
    public class ForgotPasswordDTO
    {

        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = null!;
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; } = null!;
    }
}
