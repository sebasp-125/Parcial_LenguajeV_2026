using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Shoes_v1.RealModels;

public partial class ShoesDbContext : DbContext
{
    public ShoesDbContext(DbContextOptions<ShoesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<worker> workers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<worker>(entity =>
        {
            entity.HasKey(e => e.id).HasName("workers_pkey");

            entity.Property(e => e.complete_name).HasMaxLength(100);
            entity.Property(e => e.email).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
