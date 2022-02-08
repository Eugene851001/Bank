using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class CreditObject
    {
        public CreditObject()
        {
            CreditPlans = new HashSet<CreditPlan>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CreditPlan> CreditPlans { get; set; }
    }
}
