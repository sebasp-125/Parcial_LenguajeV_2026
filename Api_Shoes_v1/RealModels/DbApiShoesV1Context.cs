using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Shoes_v1.RealModels;

public partial class DbApiShoesV1Context : DbContext
{
    public DbApiShoesV1Context()
    {
    }

    public DbApiShoesV1Context(DbContextOptions<DbApiShoesV1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Shoe> Shoes { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=dpg-d6iqll7gi27c73dh82s0-a.oregon-postgres.render.com;Database=db_api_shoes_v1;Username=db_api_shoes_v1_user;Password=a6Qt3j5NRX7KkH5yDNcDPhCzBAVQltb3;Port=5432;SSL Mode=Require;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "customers_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Completename)
                .HasMaxLength(255)
                .HasColumnName("completename");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
        });

        modelBuilder.Entity<Shoe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shoes_pkey");

            entity.ToTable("shoes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Size)
                .HasPrecision(4, 1)
                .HasColumnName("size");

            entity.HasOne(d => d.Category).WithMany(p => p.Shoes)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("fk_category");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("workers_pkey");

            entity.ToTable("workers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompleteName)
                .HasMaxLength(100)
                .HasColumnName("complete_name");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
