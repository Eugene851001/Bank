using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Credit
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Sum { get; set; }
        public double Percent { get; set; }
        public byte Currency { get; set; }
        public bool Annuity { get; set; }
        public int? CreditPlan { get; set; }
        public int MainAccount { get; set; }
        public int PercentAccount { get; set; }

        public virtual CreditPlan CreditPlanNavigation { get; set; }
        public virtual Currency CurrencyNavigation { get; set; }
        public virtual Account MainAccountNavigation { get; set; }
        public virtual Account PercentAccountNavigation { get; set; }
    }
}
