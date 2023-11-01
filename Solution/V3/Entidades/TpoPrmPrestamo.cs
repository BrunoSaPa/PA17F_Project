using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("tps_prm_prestamos")]
public partial class TpoPrmPrestamo
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [InverseProperty("IdTpoPrmPrestamoNavigation")]
    public virtual ICollection<PrmPrestamo> PrmPrestamos { get; set; } = new List<PrmPrestamo>();
}
