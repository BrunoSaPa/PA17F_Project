using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("almacenistas")]
public partial class Almacenista
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_usuario")]
    public long? IdUsuario { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public byte[]? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public byte[]? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public byte[]? FchEliminacion { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Almacenista")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
