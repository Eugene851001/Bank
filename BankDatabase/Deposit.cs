using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Deposit
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Sum { get; set; }
        public double Percent { get; set; }
        public byte Currency { get; set; }
        public bool Revocable { get; set; }
        public int? DepositPlan { get; set; }
        public int MainAccount { get; set; }
        public int PercentAccount { get; set; }

        public virtual Currency CurrencyNavigation { get; set; }
        public virtual DepositsPlan DepositPlanNavigation { get; set; }
        public virtual Account MainAccountNavigation { get; set; }
        public virtual Account PercentAccountNavigation { get; set; }
    }
}
