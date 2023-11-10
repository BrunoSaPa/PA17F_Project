using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("divisiones")]
public partial class Division
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    public DateTime? Descripcion { get; set; }

    [Column("fch_creacion")]
    public DateTime? FchCreacion { get; set; }

    [Column("fch_modificacion")]
    public DateTime? FchModificacion { get; set; }

    [Column("fch_eliminacion")]
    public DateTime? FchEliminacion { get; set; }

    [InverseProperty("IdDivisionNavigation")]
    public virtual ICollection<Salon> Salones { get; set; } = new List<Salon>();
}
