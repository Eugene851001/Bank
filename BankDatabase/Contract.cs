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
        public bool Revocable { get; set; }
        public int? DepositPlan { get; set; }

        public virtual Currency CurrencyNavigation { get; set; }
        public virtual DepositsPlan DepositPlanNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
