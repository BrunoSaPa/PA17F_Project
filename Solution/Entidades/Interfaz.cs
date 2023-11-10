using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("interfaces")]
public partial class Interfaz
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_tpo_usr_acceso")]
    public long? IdTpoUsrAcceso { get; set; }

    [Column("nombre")]
    public string? Nombre { get; set; }

    [ForeignKey("IdTpoUsrAcceso")]
    [InverseProperty("Interfaces")]
    public virtual TpsUsuario? IdTpoUsrAccesoNavigation { get; set; }
}
