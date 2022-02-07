using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class DepositType
    {
        public short Id { get; set; }
        public bool IsRevocable { get; set; }
        public int Duration { get; set; }
        public double OfflinePercentByn { get; set; }
        public double OfflinePercentUsd { get; set; }
        public double OnlinePercentByn { get; set; }
        public double OnlinePercentUsd { get; set; }
    }
}
