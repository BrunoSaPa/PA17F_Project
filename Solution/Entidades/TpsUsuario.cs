using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("tps_usuarios")]
public partial class TpsUsuario
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [InverseProperty("IdTpoUsrAccesoNavigation")]
    public virtual ICollection<Interfaz> Interfaces { get; set; } = new List<Interfaz>();

    [InverseProperty("IdTpoUsuarioNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
