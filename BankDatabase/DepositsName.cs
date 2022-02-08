using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class DepositsName
    {
        public DepositsName()
        {
            DepositsPlans = new HashSet<DepositsPlan>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DepositsPlan> DepositsPlans { get; set; }
    }
}
