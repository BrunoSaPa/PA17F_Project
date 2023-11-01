using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("materias")]
public partial class Materia
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_division")]
    public long? IdDivision { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("fch_creacion")]
    public string? FchCreacion { get; set; }

    [Column("fch_modificacion")]
    public string? FchModificacion { get; set; }

    [Column("fch_eliminacion")]
    public string? FchEliminacion { get; set; }

    [ForeignKey("IdDivision")]
    [InverseProperty("Materia")]
    public virtual Division? IdDivisionNavigation { get; set; }

    [InverseProperty("IdMateriaNavigation")]
    public virtual ICollection<Imparte> Impartes { get; set; } = new List<Imparte>();
}
