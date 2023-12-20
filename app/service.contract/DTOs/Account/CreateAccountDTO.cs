using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Account
{
    public class CreateAccountDTO: AppEntityDefaultKey
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
