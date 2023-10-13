using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace U2Actividad2.Models.Entities;

public partial class PerrosContext : DbContext
{
    public PerrosContext()
    {
    }

    public PerrosContext(DbContextOptions<PerrosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Caracteristicasfisica> Caracteristicasfisicas { get; set; }

    public virtual DbSet<Estadisticasraza> Estadisticasrazas { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=Perros;password=root;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Caracteristicasfisica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("caracteristicasfisicas")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cola).HasMaxLength(500);
            entity.Property(e => e.Color).HasMaxLength(500);
            entity.Property(e => e.Hocico).HasMaxLength(500);
            entity.Property(e => e.Patas).HasMaxLength(500);
            entity.Property(e => e.Pelo).HasMaxLength(500);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Caracteristicasfisica)
                .HasForeignKey<Caracteristicasfisica>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_caracteristicasfisicas_1");
        });

        modelBuilder.Entity<Estadisticasraza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("estadisticasraza")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Estadisticasraza)
                .HasForeignKey<Estadisticasraza>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estadisticasraza_1");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("paises")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("razas")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.IdPais, "pi_idx");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.OtrosNombres).HasMaxLength(500);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Razas)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkpai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
