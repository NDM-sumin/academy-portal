using System.ComponentModel.DataAnnotations;

namespace service.contract.DTOs.Account
{
    public class ChangePasswordDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; } = null!;
        [Required(AllowEmptyStrings = false)]
        public string OldPassword { get; set; } = null!;
    }
}
