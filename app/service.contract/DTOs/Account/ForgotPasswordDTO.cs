using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Account
{
    public class ForgotPasswordDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
