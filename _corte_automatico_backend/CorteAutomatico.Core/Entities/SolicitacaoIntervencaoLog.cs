using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("solicitacao_intervencao_log")]
[Index("Uuid", Name = "uk_solicitacao_intervencao_log_uuid", IsUnique = true)]
public partial class SolicitacaoIntervencaoLog: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("solicitacao_intervencao_id")]
    public int SolicitacaoIntervencaoId { get; set; }

    [Column("descricao")]
    [StringLength(100)]
    public string Descricao { get; set; } = null!;

    [Column("obs")]
    [StringLength(100)]
    public string Obs { get; set; } = null!;

    [Column("status_anterior")]
    public int? StatusAnterior { get; set; }

    [Column("status_corrente")]
    public int StatusCorrente { get; set; }

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

    [ForeignKey("SolicitacaoIntervencaoId")]
    [InverseProperty("SolicitacaoIntervencaoLogs")]
    public virtual SolicitacaoIntervencao SolicitacaoIntervencao { get; set; } = null!;

    [ForeignKey("StatusAnterior")]
    [InverseProperty("SolicitacaoIntervencaoLogStatusAnteriorNavigations")]
    public virtual SolicitacaoIntervencaoStatus? StatusAnteriorNavigation { get; set; }

    [ForeignKey("StatusCorrente")]
    [InverseProperty("SolicitacaoIntervencaoLogStatusCorrenteNavigations")]
    public virtual SolicitacaoIntervencaoStatus StatusCorrenteNavigation { get; set; } = null!;
}
