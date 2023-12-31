﻿#nullable disable

using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }
    private string ConnectionString { get; set; }
    public Context(string connectionString)
    {
        ConnectionString = connectionString;
    }


    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Countries> Countries { get; set; }

    public virtual DbSet<Gender> Gender { get; set; }

    public virtual DbSet<StateLookup> StateLookup { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Countries>(entity =>
        {
            entity.HasIndex(e => e.Iso, "uc_Countries_Iso").IsUnique();

            entity.Property(e => e.Iso)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Iso3)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StateLookup>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.StateAbbrev)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.StateName)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}