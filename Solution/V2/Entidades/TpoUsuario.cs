using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("tps_usuarios")]
public partial class TpoUsuario
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }
}
