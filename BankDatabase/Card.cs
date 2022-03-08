using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Card
    {
        public string Number { get; set; }
        public string Pin { get; set; }
        public int Account { get; set; }

        public virtual Account AccountNavigation { get; set; }
    }
}
