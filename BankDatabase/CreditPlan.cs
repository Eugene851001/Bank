using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class CreditPlan
    {
        public CreditPlan()
        {
            Credits = new HashSet<Credit>();
        }

        public int Id { get; set; }
        public int Duration { get; set; }
        public double Percent { get; set; }
        public byte Name { get; set; }
        public byte? Object { get; set; }
        public decimal? MinValue { get; set; }
        public bool Annuity { get; set; }

        public virtual CreditsName NameNavigation { get; set; }
        public virtual CreditObject ObjectNavigation { get; set; }
        public virtual ICollection<Credit> Credits { get; set; }
    }
}
