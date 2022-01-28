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

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Disability> Disabilities { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public int Save()
        {
            return SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=DESKTOP-02TU7RG\\SQLEXPRESS;initial catalog=Bank;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.ResidenceCity, "IXFK_Users_Cities");

                entity.HasIndex(e => e.Citizenship, "IXFK_Users_Countries");

                entity.HasIndex(e => e.Disability, "IXFK_Users_Disabilities");

                entity.HasIndex(e => e.MaritalStatus, "IXFK_Users_MaritalStatuses");

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
