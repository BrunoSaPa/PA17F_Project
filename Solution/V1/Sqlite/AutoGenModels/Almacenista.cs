using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("almacenistas")]
public class Almacenista
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public DateTime FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public DateTime FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public DateTime FchEliminacion { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Almacenista")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
