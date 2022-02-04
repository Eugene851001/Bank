using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class AccountsType
    {
        public AccountsType()
        {
            Accounts = new HashSet<Account>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
