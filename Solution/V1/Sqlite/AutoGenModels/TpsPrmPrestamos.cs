using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("tps_prm_prestamos")]
public class TpsPrmPrestamos
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [InverseProperty("IdTpoPrmPrestamoNavigation")]
    public virtual ICollection<PrmPrestamos> PrmPrestamos { get; set; } = new List<PrmPrestamos>();
}
