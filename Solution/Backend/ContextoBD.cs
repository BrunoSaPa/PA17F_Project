namespace Backend;

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using Entidades;

public partial class ContextoBD : DbContext
{
    public ContextoBD()
    {
    }

    public ContextoBD(DbContextOptions<ContextoBD> options)
        : base(options)
    {
    }



      private readonly string connectionString;
        
    public ContextoBD(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public virtual DbSet<Almacenista> Almacenistas { get; set; }

    public virtual DbSet<Coordinador> Coordinadores { get; set; }

    public virtual DbSet<Division> Divisiones { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<EquiposPrm> EquiposPrms { get; set; }

    public virtual DbSet<EstPrmPrestamo> EstPrmPrestamos { get; set; }

    public virtual DbSet<EstUsuario> EstUsuarios { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Interfaz> Interfaces { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<PrmPrestamo> PrmPrestamos { get; set; }

    public virtual DbSet<Profesor> Profesores { get; set; }

    public virtual DbSet<Salon> Salones { get; set; }

    public virtual DbSet<TpsMantenimiento> TpsMantenimientos { get; set; }

    public virtual DbSet<TpsPrmPrestamo> TpsPrmPrestamos { get; set; }

    public virtual DbSet<TpsUsuario> TpsUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Filename=../BD/Avanzada.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacenista>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Coordinador>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
            entity.Property(e => e.FchEliminacion).HasDefaultValueSql("'0000-00-00 00:00:00'");
            entity.Property(e => e.FchModificacion).HasDefaultValueSql("'0000-00-00 00:00:00'");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<EquiposPrm>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdEquiposNavigation).WithMany(p => p.EquiposPrms).OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.IdPrmPrestamoNavigation).WithMany(p => p.EquiposPrms).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<PrmPrestamo>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
            entity.Property(e => e.FchInicio).HasDefaultValueSql("datetime('now')");

            entity.HasOne(d => d.IdEstPrmPrestamosNavigation).WithMany(p => p.PrmPrestamos).OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.IdSalonNavigation).WithMany(p => p.PrmPrestamos).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Profesores).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.FchCreacion).HasDefaultValueSql("datetime('now')");
            entity.Property(e => e.Nombre).HasDefaultValueSql("''");

            entity.HasOne(d => d.IdEstUsuarioNavigation).WithMany(p => p.Usuarios).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdTpoUsuarioNavigation).WithMany(p => p.Usuarios).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

   
	public int ObtenerIdUsuarioPorRegistro(string registro)
	{
	    int resultado = 0;
	
	    try
	    {
	        string filePath = @"../BD/sp_slc_usr_registro.txt";
	        string sqlScript = File.ReadAllText(filePath);
	
	        using (var connection = new SqliteConnection(connectionString)) // Reemplaza 'connectionString' con tu cadena de conexión
	        {
	            connection.Open();
	
	            using (var command = connection.CreateCommand())
	            {
	                command.CommandText = sqlScript;
	                command.Parameters.Add(new SqliteParameter("@registro", registro));
	
	                using (var reader = command.ExecuteReader())
	                {
	                    if (reader.Read())
	                    {
	                        resultado = reader.GetInt32(0);
	                        //Console.WriteLine($"ID de usuario encontrado: {resultado}");
	                    }
	                    else
	                    {
	                        Console.WriteLine("No se encontró ningún ID de usuario.");
	                    }
	                }
	            }
	        }
	    }
	    catch (Exception e)
	    {
	        Console.WriteLine("Error al ejecutar la consulta SQL.");
	        Console.WriteLine($"Excepción: {e.ToString}");
	    }
	
	    return resultado;
	}
}
