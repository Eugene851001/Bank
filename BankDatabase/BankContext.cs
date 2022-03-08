using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BankDatabase
{
    public partial class BankContext : DbContext, IBankContext
    {
        public BankContext()
        {
        }

        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountsType> AccountsTypes { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<CreditPlan> CreditPlans { get; set; }
        public virtual DbSet<CreditsName> CreditsNames { get; set; }
        public virtual DbSet<CreditsObject> CreditsObjects { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<DepositsName> DepositsNames { get; set; }
        public virtual DbSet<DepositsPlan> DepositsPlans { get; set; }
        public virtual DbSet<Disability> Disabilities { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<SystemVariable> SystemVariables { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=DESKTOP-02TU7RG\\SQLEXPRESS;initial catalog=Bank;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.AccountType, "IXFK_Accounts_AccountsTypes");

                entity.HasIndex(e => e.Currency, "IXFK_Accounts_Currencies");

                entity.HasIndex(e => e.Owner, "IXFK_Accounts_Users");

                entity.Property(e => e.Balance)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(([Credit]-[Debit])+((2)*[Active])*([Debit]-[Credit]))", true);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Credit).HasColumnType("money");

                entity.Property(e => e.Debit).HasColumnType("money");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.AccountTypeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accounts_AccountsTypes");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accounts_Currencies");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_Accounts_Users");
            });

            modelBuilder.Entity<AccountsType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.HasIndex(e => e.Account, "IXFK_Cards_Accounts");

                entity.Property(e => e.Number)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.Account)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cards_Accounts");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Credit>(entity =>
            {
                entity.HasIndex(e => e.Id, "IXFK_Credits_Accounts");

                entity.HasIndex(e => e.MainAccount, "IXFK_Credits_Accounts_02");

                entity.HasIndex(e => e.PercentAccount, "IXFK_Credits_Accounts_03");

                entity.HasIndex(e => e.CreditPlan, "IXFK_Credits_CreditPlans");

                entity.HasIndex(e => e.Currency, "IXFK_Credits_Currencies");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.CreditPlanNavigation)
                    .WithMany(p => p.Credits)
                    .HasForeignKey(d => d.CreditPlan)
                    .HasConstraintName("FK_Credits_CreditPlans");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.Credits)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credits_Currencies");

                entity.HasOne(d => d.MainAccountNavigation)
                    .WithMany(p => p.CreditMainAccountNavigations)
                    .HasForeignKey(d => d.MainAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credits_Accounts_02");

                entity.HasOne(d => d.PercentAccountNavigation)
                    .WithMany(p => p.CreditPercentAccountNavigations)
                    .HasForeignKey(d => d.PercentAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credits_Accounts_03");
            });

            modelBuilder.Entity<CreditPlan>(entity =>
            {
                entity.HasIndex(e => e.Object, "IXFK_CreditPlans_CreditObject");

                entity.HasIndex(e => e.Name, "IXFK_CreditPlans_CreditsNames");

                entity.HasIndex(e => e.Currency, "IXFK_CreditPlans_Currencies");

                entity.Property(e => e.MinValue).HasColumnType("money");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.CreditPlans)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditPlans_Currencies");

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.CreditPlans)
                    .HasForeignKey(d => d.Name)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditPlans_CreditsNames");

                entity.HasOne(d => d.ObjectNavigation)
                    .WithMany(p => p.CreditPlans)
                    .HasForeignKey(d => d.Object)
                    .HasConstraintName("FK_CreditPlans_CreditObject");
            });

            modelBuilder.Entity<CreditsName>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CreditsObject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasIndex(e => e.Currency, "IXFK_Contracts_Currencies");

                entity.HasIndex(e => e.DepositPlan, "IXFK_Contracts_DepositsPlans");

                entity.HasIndex(e => e.MainAccount, "IXFK_Deposits_Accounts");

                entity.HasIndex(e => e.PercentAccount, "IXFK_Deposits_Accounts_02");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contracts_Currencies");

                entity.HasOne(d => d.DepositPlanNavigation)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.DepositPlan)
                    .HasConstraintName("FK_Contracts_DepositsPlans");

                entity.HasOne(d => d.MainAccountNavigation)
                    .WithMany(p => p.DepositMainAccountNavigations)
                    .HasForeignKey(d => d.MainAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deposits_Accounts");

                entity.HasOne(d => d.PercentAccountNavigation)
                    .WithMany(p => p.DepositPercentAccountNavigations)
                    .HasForeignKey(d => d.PercentAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deposits_Accounts_02");
            });

            modelBuilder.Entity<DepositsName>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DepositsPlan>(entity =>
            {
                entity.HasIndex(e => e.Currency, "IXFK_DepositsPlans_Currencies");

                entity.HasIndex(e => e.Name, "IXFK_DepositsPlans_DepositsNames");

                entity.Property(e => e.MinValue).HasColumnType("money");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.DepositsPlans)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepositsPlans_Currencies");

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.DepositsPlans)
                    .HasForeignKey(d => d.Name)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepositsPlans_DepositsNames");
            });

            modelBuilder.Entity<Disability>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemVariable>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CurrentDate).HasColumnType("date");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(e => e.Source, "IXFK_Transactions_Accounts");

                entity.HasIndex(e => e.Destination, "IXFK_Transactions_Accounts_02");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.DestinationNavigation)
                    .WithMany(p => p.TransactionDestinationNavigations)
                    .HasForeignKey(d => d.Destination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Accounts_02");

                entity.HasOne(d => d.SourceNavigation)
                    .WithMany(p => p.TransactionSourceNavigations)
                    .HasForeignKey(d => d.Source)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Accounts");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.ResidenceCity, "IXFK_Users_Cities");

                entity.HasIndex(e => e.Citizenship, "IXFK_Users_Countries");

                entity.HasIndex(e => e.Disability, "IXFK_Users_Disabilities");

                entity.HasIndex(e => e.MaritalStatus, "IXFK_Users_MaritalStatuses");

                entity.HasIndex(e => e.PassportId, "UNQ_PassportId")
                    .IsUnique();

                entity.HasIndex(e => e.PassportNumber, "UNQ_PassportNumber")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.BirthPlace)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IssuedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IssuedDate).HasColumnType("date");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonthlyIncome).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PassportId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PassportSeries)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResidenceAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CitizenshipNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Citizenship)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Countries");

                entity.HasOne(d => d.DisabilityNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Disability)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Disabilities");

                entity.HasOne(d => d.MaritalStatusNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.MaritalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_MaritalStatuses");

                entity.HasOne(d => d.ResidenceCityNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ResidenceCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Cities");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
