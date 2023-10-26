﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("usuarios")]
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
    public byte[]? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public byte[]? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public byte[]? FchEliminacion { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Almacenista> Almacenista { get; set; } = new List<Almacenista>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Coordinadore> Coordinadores { get; set; } = new List<Coordinadore>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<PrmPrestamo> PrmPrestamos { get; set; } = new List<PrmPrestamo>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Profesore> Profesores { get; set; } = new List<Profesore>();
}
