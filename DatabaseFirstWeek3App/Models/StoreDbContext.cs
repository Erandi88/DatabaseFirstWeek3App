using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstWeek3App.Models;

public partial class StoreDbContext : DbContext
{
    public StoreDbContext()
    {
    }

    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSale> ProductSales { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<StaffInformation> StaffInformations { get; set; }

    public virtual DbSet<StaffType> StaffTypes { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreStaff> StoreStaffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-BT36K8P;Initial Catalog=StoreDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<ProductSale>(entity =>
        {
            entity.ToTable("ProductSale");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSale_Product");

            entity.HasOne(d => d.Sales).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSale_Sales");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfSale).HasColumnType("datetime");

            entity.HasOne(d => d.Staff).WithMany(p => p.Sales)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Staffs");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<StaffInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Staff_information");

            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("DATE_OF_BIRTH");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.WorkPlace)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("WORK_PLACE");
        });

        modelBuilder.Entity<StaffType>(entity =>
        {
            entity.ToTable("StaffType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.StaffType)
                .HasForeignKey<StaffType>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaffType_Staffs");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<StoreStaff>(entity =>
        {
            entity.ToTable("StoreStaff");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");

            entity.HasOne(d => d.Staff).WithMany(p => p.StoreStaffs)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreStaff_Staffs");

            entity.HasOne(d => d.Store).WithMany(p => p.StoreStaffs)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreStaff_Stores");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
