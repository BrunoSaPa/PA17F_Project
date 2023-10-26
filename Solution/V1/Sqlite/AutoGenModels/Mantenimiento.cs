using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("mantenimiento")]
public partial class Mantenimiento
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_tpo_mantenimiento")]
    public long? IdTpoMantenimiento { get; set; }

    [Column("id_equipo")]
    public long? IdEquipo { get; set; }

    [Column("descripciones")]
    public string? Descripciones { get; set; }

    [Column("refaccion")]
    public string? Refaccion { get; set; }

    [Column("fch_inicio", TypeName = "DATETIME")]
    public byte[]? FchInicio { get; set; }

    [Column("fch_fin", TypeName = "DATETIME")]
    public byte[]? FchFin { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public byte[]? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public byte[]? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public byte[]? FchEliminacion { get; set; }
}
