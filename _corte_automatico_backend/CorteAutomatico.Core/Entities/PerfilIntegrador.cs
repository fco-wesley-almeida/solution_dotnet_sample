using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("perfil_integrador")]
[Index("Uuid", Name = "uk_perfil_integrador_uuid", IsUnique = true)]
public partial class PerfilIntegrador: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("perfil_id")]
    public int PerfilId { get; set; }

    [Column("integrador_id")]
    public int IntegradorId { get; set; }

    [Column("criado_por")]
    [StringLength(100)]
    public string CriadoPor { get; set; } = null!;

    [Column("criado_em", TypeName = "timestamp without time zone")]
    public DateTime CriadoEm { get; set; }

    [Column("modificado_por")]
    [StringLength(100)]
    public string ModificadoPor { get; set; } = null!;

    [Column("modificado_em", TypeName = "timestamp without time zone")]
    public DateTime ModificadoEm { get; set; }

    [Column("ativo")]
    public bool Ativo { get; set; }

    [ForeignKey("IntegradorId")]
    [InverseProperty("PerfilIntegradors")]
    public virtual Integrador Integrador { get; set; } = null!;

    [ForeignKey("PerfilId")]
    [InverseProperty("PerfilIntegradors")]
    public virtual Perfil Perfil { get; set; } = null!;
}
