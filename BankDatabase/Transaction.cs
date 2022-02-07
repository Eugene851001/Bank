using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int Source { get; set; }
        public int Destination { get; set; }
        public decimal Sum { get; set; }
        public DateTime? Time { get; set; }

        public virtual Account DestinationNavigation { get; set; }
        public virtual Account SourceNavigation { get; set; }
    }
}
