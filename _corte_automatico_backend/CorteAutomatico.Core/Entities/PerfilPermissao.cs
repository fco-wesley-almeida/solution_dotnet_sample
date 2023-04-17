using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("perfil_permissao")]
[Index("Uuid", Name = "uk_perfil_permissao_uuid", IsUnique = true)]
public partial class PerfilPermissao: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("perfil_id")]
    public int PerfilId { get; set; }

    [Column("permissao_id")]
    public int PermissaoId { get; set; }

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

    [ForeignKey("PerfilId")]
    [InverseProperty("PerfilPermissaos")]
    public virtual Perfil Perfil { get; set; } = null!;

    [ForeignKey("PermissaoId")]
    [InverseProperty("PerfilPermissaos")]
    public virtual Permissao Permissao { get; set; } = null!;
}
