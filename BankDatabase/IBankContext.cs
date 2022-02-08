using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDatabase
{
    public interface IBankContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountsType> AccountsTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<CreditObject> CreditObjects { get; set; }
        public DbSet<CreditPlan> CreditPlans { get; set; }
        public DbSet<CreditsName> CreditsNames { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<DepositsName> DepositsNames { get; set; }
        public DbSet<DepositsPlan> DepositsPlans { get; set; }
        public DbSet<Disability> Disabilities { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<SystemVariable> SystemVariables { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        int SaveChanges(); 
    }
}
