using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParkMe.Models;

public partial class ParkMeContext : DbContext
{
    public ParkMeContext()
    {
    }

    public ParkMeContext(DbContextOptions<ParkMeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deck> Decks { get; set; }

    public virtual DbSet<Spot> Spots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSpotMapping> UserSpotMappings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=ParkMe;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deck>(entity =>
        {
            entity.Property(e => e.DeckId).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Spot>(entity =>
        {
            entity.Property(e => e.SpotId).ValueGeneratedNever();
            entity.Property(e => e.SpotName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Deck).WithMany(p => p.Spots)
                .HasForeignKey(d => d.DeckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spots_Decks1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.CampusId);

            entity.Property(e => e.CampusId).HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<UserSpotMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserSpotMapping");

            entity.Property(e => e.CampusId)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Charge).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
