using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("usuarios")]
[Index("Id", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_tpo_usuario")]
    public long IdTpoUsuario { get; set; }

    [Column("id_est_usuario")]
    public long IdEstUsuario { get; set; }

    [Column("contrasena")]
    public byte[]? Contrasena { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; } = null!;

    [Column("apl_materno")]
    public string? AplMaterno { get; set; }

    [Column("apl_paterno")]
    public string? AplPaterno { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public DateTime? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public DateTime? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public DateTime? FchEliminacion { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Almacenista> Almacenista { get; set; } = new List<Almacenista>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Coordinador> Coordinadores { get; set; } = new List<Coordinador>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    [ForeignKey("IdEstUsuario")]
    [InverseProperty("Usuarios")]
    public virtual EstUsuario IdEstUsuarioNavigation { get; set; } = null!;

    [ForeignKey("IdTpoUsuario")]
    [InverseProperty("Usuarios")]
    public virtual TpoUsuario IdTpoUsuarioNavigation { get; set; } = null!;

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<PrmPrestamo> PrmPrestamos { get; set; } = new List<PrmPrestamo>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Profesor> Profesores { get; set; } = new List<Profesor>();
}
