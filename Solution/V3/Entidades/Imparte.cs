using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("imparte")]
public partial class Imparte
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_profesor")]
    public long? IdProfesor { get; set; }

    [Column("id_materia")]
    public long? IdMateria { get; set; }

    [ForeignKey("IdMateria")]
    [InverseProperty("Impartes")]
    public virtual Materia? IdMateriaNavigation { get; set; }

    [ForeignKey("IdProfesor")]
    [InverseProperty("Impartes")]
    public virtual Profesor? IdProfesorNavigation { get; set; }
}
