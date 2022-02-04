using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Contract
    {
        public Contract()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Sum { get; set; }
        public double Percent { get; set; }
        public byte Currency { get; set; }
        public short? DepositType { get; set; }

        public virtual Currency CurrencyNavigation { get; set; }
        public virtual DepositType DepositTypeNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
