using BlazorProjekt.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Context
{
    public class BlazorBankContext : DbContext
    {
        public BlazorBankContext(DbContextOptions<BlazorBankContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Credential> Credentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(o => o.AccountId);
            modelBuilder.Entity<AccountType>().HasKey(o => o.AccountTypeId);
            modelBuilder.Entity<Owner>().HasKey(o => o.OwnerId);
            modelBuilder.Entity<Sex>().HasKey(o => o.SexId);
            modelBuilder.Entity<Credential>().HasKey(o => o.CredentialId);

            modelBuilder.Entity<Account>().HasOne(o => o.AccountType).WithMany(o => o.Accounts).HasForeignKey(o => o.FKAccountTypeId);
            modelBuilder.Entity<Account>().HasOne(o => o.Owner).WithMany(o => o.Accounts).HasForeignKey(o => o.FKOwnerId);
            modelBuilder.Entity<Owner>().HasOne(o => o.Sex).WithMany(o => o.Owners).HasForeignKey(o => o.FKSexId);
            modelBuilder.Entity<Owner>().HasOne(o => o.Credential).WithOne(o => o.Owner).HasForeignKey<Credential>(o => o.FKOwnerId);

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType { AccountTypeId = 1, Name = "CheckingsAccount", MinimumAge = 18, Interrest = 0.05m },
                new AccountType { AccountTypeId = 2, Name = "SavingsAccount", MinimumAge = 0, Interrest = 0.07m },
                new AccountType { AccountTypeId = 3, Name = "YouthAccount", MinimumAge = 13, Interrest = 0.09m });

            modelBuilder.Entity<Sex>().HasData(
                new Sex { SexId = 1, Name = "Male" },
                new Sex { SexId = 2, Name = "Female" },
                new Sex { SexId = 3, Name = "Transsexual Male" },
                new Sex { SexId = 4, Name = "Transsexual Female" });

            modelBuilder.Entity<Owner>().HasData(
               new Owner { OwnerId = 1, Name = "Jimmy Elkjer", FKSexId = 1, Age = 20 },
               new Owner { OwnerId = 2, Name = "Kenneth Jessen", FKSexId = 1, Age = 22 },
               new Owner { OwnerId = 3, Name = "Kristian Biehl Kuhrt", FKSexId = 3, Age = 20 });

            modelBuilder.Entity<Account>().HasData(
                new Account { AccountId = 1, FKAccountTypeId = 1, Balance = 100000.5m, FKOwnerId = 1 },
                new Account { AccountId = 2, FKAccountTypeId = 2, Balance = 1000000m, FKOwnerId = 2 },
                new Account { AccountId = 3, FKAccountTypeId = 3, Balance = 1000.1m, FKOwnerId = 3 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
