using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class DepositsPlan
    {
        public DepositsPlan()
        {
            Contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public byte Name { get; set; }
        public byte Currency { get; set; }
        public int Duration { get; set; }
        public bool Revocable { get; set; }
        public double Percent { get; set; }
        public bool Online { get; set; }
        public decimal? MinValue { get; set; }

        public virtual Currency CurrencyNavigation { get; set; }
        public virtual DepositsName NameNavigation { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
