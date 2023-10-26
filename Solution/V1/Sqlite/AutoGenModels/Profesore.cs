﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("profesores")]
public partial class Profesore
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_usuario")]
    public long? IdUsuario { get; set; }

    [Column("nomina")]
    public long? Nomina { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public byte[]? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public byte[]? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public byte[]? FchEliminacion { get; set; }

    [InverseProperty("IdProfesorNavigation")]
    public virtual ICollection<Ensena> Ensenas { get; set; } = new List<Ensena>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Profesores")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [InverseProperty("IdProfesorNavigation")]
    public virtual ICollection<Imparte> Impartes { get; set; } = new List<Imparte>();
}
