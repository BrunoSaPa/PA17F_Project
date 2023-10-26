using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

public partial class sqlite : DbContext
{
    public sqlite()
    {
    }

    public sqlite(DbContextOptions<sqlite> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacenista> Almacenistas { get; set; }

    public virtual DbSet<Coordinadore> Coordinadores { get; set; }

    public virtual DbSet<Divisione> Divisiones { get; set; }

    public virtual DbSet<Ensena> Ensenas { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<EstUsuario> EstUsuarios { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Imparte> Impartes { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Materias> Materias { get; set; }

    public virtual DbSet<PrmPrestamos> PrmPrestamos { get; set; }

    public virtual DbSet<Profesores> Profesores { get; set; }

    public virtual DbSet<RlcPrsEquipo> RlcPrsEquipos { get; set; }

    public virtual DbSet<Salones> Salones { get; set; }

    public virtual DbSet<TpsMantenimiento> TpsMantenimiento { get; set; }

    public virtual DbSet<TpsPrmPrestamos> TpsPrmPrestamos { get; set; }

    public virtual DbSet<TpsUsuarios> TpsUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Filename=Avanzada.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacenista>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Coordinadore>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Divisione>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
            entity.Property(e => e.FchEliminacion).HasDefaultValueSql("'0000-00-00 00:00:00'");
            entity.Property(e => e.FchModificacion).HasDefaultValueSql("'0000-00-00 00:00:00'");
        });

        modelBuilder.Entity<Ensena>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Imparte>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Materias>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
            entity.Property(e => e.FchEliminacion).HasDefaultValueSql("'0000-00-00 00:00:00'");
            entity.Property(e => e.FchModificacion).HasDefaultValueSql("'0000-00-00 00:00:00'");
        });

        modelBuilder.Entity<PrmPrestamos>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
            entity.Property(e => e.FchInicio).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Profesores>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<RlcPrsEquipo>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Salones>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
            entity.Property(e => e.Nombre).HasDefaultValueSql("''");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
