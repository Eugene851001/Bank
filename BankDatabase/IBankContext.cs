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
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DepositType> DepositTypes { get; set; }
        public DbSet<Disability> Disabilities { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<User> Users { get; set; }

        int SaveChanges(); 
    }
}
