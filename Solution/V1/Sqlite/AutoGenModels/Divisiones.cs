using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("divisiones")]
public class Divisiones
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("fch_creacion")]
    public string? FchCreacion { get; set; }

    [Column("fch_modificacion")]
    public string? FchModificacion { get; set; }

    [Column("fch_eliminacion")]
    public string? FchEliminacion { get; set; }

    [InverseProperty("IdDivisionNavigation")]
    public virtual ICollection<Materias> Materia { get; set; } = new List<Materias>();

    [InverseProperty("IdDivisionNavigation")]
    public virtual ICollection<Salone> Salones { get; set; } = new List<Salone>();
}
