using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Account
    {
        public Account()
        {
            CreditMainAccountNavigations = new HashSet<Credit>();
            CreditPercentAccountNavigations = new HashSet<Credit>();
            DepositMainAccountNavigations = new HashSet<Deposit>();
            DepositPercentAccountNavigations = new HashSet<Deposit>();
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
        public decimal? Balance { get; set; }

        public virtual AccountsType AccountTypeNavigation { get; set; }
        public virtual Currency CurrencyNavigation { get; set; }
        public virtual User OwnerNavigation { get; set; }
        public virtual ICollection<Credit> CreditMainAccountNavigations { get; set; }
        public virtual ICollection<Credit> CreditPercentAccountNavigations { get; set; }
        public virtual ICollection<Deposit> DepositMainAccountNavigations { get; set; }
        public virtual ICollection<Deposit> DepositPercentAccountNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionDestinationNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionSourceNavigations { get; set; }
    }
}
