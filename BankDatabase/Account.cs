using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Account
    {
        public Account()
        {
            TransactionDestinationNavigations = new HashSet<Transaction>();
            TransactionSourceNavigations = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public byte Active { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int? Owner { get; set; }
        public byte AccountType { get; set; }
        public byte Currency { get; set; }
        public int? Contract { get; set; }
        public decimal? Balance { get; set; }

        public virtual AccountsType AccountTypeNavigation { get; set; }
        public virtual Contract ContractNavigation { get; set; }
        public virtual Currency CurrencyNavigation { get; set; }
        public virtual User OwnerNavigation { get; set; }
        public virtual ICollection<Transaction> TransactionDestinationNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionSourceNavigations { get; set; }
    }
}
