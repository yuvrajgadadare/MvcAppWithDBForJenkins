using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MvcAppWithDBForJenkins.Models;

public partial class CoreapidbContext : DbContext
{
    public CoreapidbContext()
    {
    }

    public CoreapidbContext(DbContextOptions<CoreapidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<Tblemployee> Tblemployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=115.124.106.98;Database=coreapidb;User Id=coreapiuser;Password=P0wersh#t#2026;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("coreapiuser");

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tblCusto__A4AE64D82C6760C1");

            entity.ToTable("tblCustomers", "dbo");

            entity.HasIndex(e => e.MobileNumber, "UQ__tblCusto__250375B1B4E27C0B").IsUnique();

            entity.HasIndex(e => e.MobileNumber, "UQ__tblCusto__250375B1D11C89D5").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "UQ__tblCusto__49A147403662EB00").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "UQ__tblCusto__49A147409F4685E8").IsUnique();

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__tblProdu__B40CC6CD9AE61534");

            entity.ToTable("tblProducts", "dbo");

            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tblemployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__tblemplo__C52E0BA83EF6F507");

            entity.ToTable("tblemployees", "dbo");

            entity.HasIndex(e => e.EmployeeCode, "UQ__tblemplo__B0AA7345CDC14887").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("employee_code");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
