using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Account
{
    public class AccountNoPasswordDTO : AppEntityDefaultKeyDTO
    {
        public string Username { get; set; } = null!;
    }
}
