using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
