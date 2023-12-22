using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Role : AppEntityDefaultKey
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }
        public string RoleName { get; set; } = null!;
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
