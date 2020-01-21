﻿// <auto-generated />
using BlazorProjekt.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorProjekt.Repository.Migrations
{
    [DbContext(typeof(BlazorBankContext))]
    [Migration("20200121134044_RemovedFKCredentialIdFromOwnersTable")]
    partial class RemovedFKCredentialIdFromOwnersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorProjekt.Repository.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("FKAccountTypeId")
                        .HasColumnType("int");

                    b.Property<int>("FKOwnerId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("FKAccountTypeId");

                    b.HasIndex("FKOwnerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            Balance = 100000.5m,
                            FKAccountTypeId = 1,
                            FKOwnerId = 1
                        },
                        new
                        {
                            AccountId = 2,
                            Balance = 1000000m,
                            FKAccountTypeId = 2,
                            FKOwnerId = 2
                        },
                        new
                        {
                            AccountId = 3,
                            Balance = 1000.1m,
                            FKAccountTypeId = 3,
                            FKOwnerId = 3
                        });
                });

            modelBuilder.Entity("BlazorProjekt.Repository.Entities.AccountType", b =>
                {
                    b.Property<int>("AccountTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Interrest")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MinimumAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountTypeId");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            AccountTypeId = 1,
                            Interrest = 0.05m,
                            MinimumAge = 18,
                            Name = "CheckingsAccount"
                        },
                        new
                        {
                            AccountTypeId = 2,
                            Interrest = 0.07m,
                            MinimumAge = 0,
                            Name = "SavingsAccount"
                        },
                        new
                        {
                            AccountTypeId = 3,
                            Interrest = 0.09m,
                            MinimumAge = 13,
                            Name = "YouthAccount"
                        });
                });

            modelBuilder.Entity("BlazorProjekt.Repository.Entities.Credential", b =>
                {
                    b.Property<int>("CredentialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FKOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedUsername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CredentialId");

                    b.HasIndex("FKOwnerId")
                        .IsUnique();

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("BlazorProjekt.Repository.Entities.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("FKSexId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.HasIndex("FKSexId");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            OwnerId = 1,
                            Admin = false,
                            Age = 20,
                            FKSexId = 1,
                            Name = "Jimmy Elkjer"
                        },
                        new
                        {
                            OwnerId = 2,
                            Admin = false,
                            Age = 22,
                            FKSexId = 1,
                            Name = "Kenneth Jessen"
                        },
                        new
                        {
                            OwnerId = 3,
                            Admin = false,
                            Age = 20,
                            FKSexId = 3,
                            Name = "Kristian Biehl Kuhrt"
                        });
                });

            modelBuilder.Entity("BlazorProjekt.Repository.Entities.Sex", b =>
                {
                    b.Property<int>("SexId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SexId");

                    b.ToTable("Sexes");

                    b.HasData(
                        new
                        {
                            SexId = 1,
                            Name = "Male"
                        },
                        new
                        {
                            SexId = 2,
                            Name = "Female"
                        },
                        new
                        {
                            SexId = 3,
                            Name = "Transsexual Male"
                        },
                        new
                        {
                            SexId = 4,
                            Name = "Transsexual Female"
                        });
                });

            modelBuilder.Entity("BlazorProjekt.Repository.Entities.Account", b =>
                {
                    b.HasOne("BlazorProjekt.Repository.Entities.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("FKAccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorProjekt.Repository.Entities.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("FKOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorProjekt.Repository.Entities.Credential", b =>
                {
                    b.HasOne("BlazorProjekt.Repository.Entities.Owner", "Owner")
                        .WithOne("Credential")
                        .HasForeignKey("BlazorProjekt.Repository.Entities.Credential", "FKOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorProjekt.Repository.Entities.Owner", b =>
                {
                    b.HasOne("BlazorProjekt.Repository.Entities.Sex", "Sex")
                        .WithMany("Owners")
                        .HasForeignKey("FKSexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
