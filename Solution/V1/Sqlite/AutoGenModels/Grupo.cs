using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("grupos")]
public partial class Grupo
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("nombre")]
    public string? Nombre { get; set; }

    [InverseProperty("IdGrupoNavigation")]
    public virtual ICollection<Ensena> Ensenas { get; set; } = new List<Ensena>();

    [InverseProperty("IdGrupoNavigation")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
