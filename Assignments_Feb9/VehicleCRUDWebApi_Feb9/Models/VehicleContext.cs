﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleCRUDWebApi_Feb9.Models
{
    public partial class VehicleContext : DbContext
    {
        public VehicleContext()
        {
        }

        public VehicleContext(DbContextOptions<VehicleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VehicleDetail> VehicleDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=IN3238387W1\\SQLEXPRESS;Initial Catalog=Vehicle;Trusted_Connection=True;TrustServerCertificate=True;database=Vehicle");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDetail>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.Property(e => e.VehicleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
