using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("instalacao_dispositivo")]
[Index("Uuid", Name = "uk_instalacao_dispositivo_uuid", IsUnique = true)]
public partial class InstalacaoDispositivo: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("dispositivo_id")]
    public int DispositivoId { get; set; }

    [Column("instalacao_id")]
    public int InstalacaoId { get; set; }

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

    [ForeignKey("DispositivoId")]
    [InverseProperty("InstalacaoDispositivos")]
    public virtual Dispositivo Dispositivo { get; set; } = null!;

    [ForeignKey("InstalacaoId")]
    [InverseProperty("InstalacaoDispositivos")]
    public virtual Instalacao Instalacao { get; set; } = null!;
}
