using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
