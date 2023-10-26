using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("salones")]
public partial class Salone
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_division")]
    public long? IdDivision { get; set; }

    [Column("nmr_salon")]
    public long? NmrSalon { get; set; }

    [ForeignKey("IdDivision")]
    [InverseProperty("Salones")]
    public virtual Divisione? IdDivisionNavigation { get; set; }
}
