﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using AmeliorateAegis.ExternalModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AmeliorateAegis.Data
{
    public partial class RegionalContext : DbContext
    {
        public RegionalContext()
        {
        }

        public RegionalContext(DbContextOptions<RegionalContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<Center> Center { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractItems> ContractItems { get; set; }
        public virtual DbSet<Regional_Center> Regional_Center { get; set; }
        public virtual DbSet<ScheduleVisit> ScheduleVisit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=Regional.Database;Integrated Security=true");

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.Property(e => e.BalanceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BudgetAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BudgetDescr)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Center>(entity =>
            {
                entity.Property(e => e.Addressline1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Addressline2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CenterCode).HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Suburb)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.ContractDescr).IsRequired();

                entity.Property(e => e.ContractName).IsRequired();

                entity.Property(e => e.Date).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ContractItems>(entity =>
            {
                entity.HasKey(e => e.ContractItemID);

                entity.Property(e => e.ContractItem)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Regional_Center>(entity =>
            {
                entity.HasKey(e => e.RegionalCenterID);

                entity.Property(e => e.RegionalCenterID).ValueGeneratedNever();
            });

            modelBuilder.Entity<ScheduleVisit>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.ReasonForVisit).HasMaxLength(250);

                entity.Property(e => e.Time)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.VisitDescr).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}