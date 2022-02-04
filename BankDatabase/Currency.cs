using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Currency
    {
        public Currency()
        {
            Accounts = new HashSet<Account>();
            Contracts = new HashSet<Contract>();
        }

        public byte Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
