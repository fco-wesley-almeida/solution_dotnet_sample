using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("solicitacao_intervencao")]
[Index("Uuid", Name = "uk_solicitacao_intervencao_uuid", IsUnique = true)]
public partial class SolicitacaoIntervencao: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("financiamento_id")]
    public int FinanciamentoId { get; set; }

    [Column("tipo_solicitacao_intervencao_id")]
    public int TipoSolicitacaoIntervencaoId { get; set; }

    [Column("solicitacao_intervencao_status_id")]
    public int SolicitacaoIntervencaoStatusId { get; set; }

    [Column("motivo_solicitacao")]
    [StringLength(100)]
    public string MotivoSolicitacao { get; set; } = null!;

    [Column("data_agendamento_intervencao")]
    public DateOnly DataAgendamentoIntervencao { get; set; }

    [Column("hora_agendamento_intervencao")]
    public TimeOnly HoraAgendamentoIntervencao { get; set; }

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

    [ForeignKey("FinanciamentoId")]
    [InverseProperty("SolicitacaoIntervencaos")]
    public virtual Financiamento Financiamento { get; set; } = null!;

    [InverseProperty("SolicitacaoIntervencao")]
    public virtual ICollection<SolicitacaoIntervencaoLog> SolicitacaoIntervencaoLogs { get; } = new List<SolicitacaoIntervencaoLog>();

    [ForeignKey("SolicitacaoIntervencaoStatusId")]
    [InverseProperty("SolicitacaoIntervencaos")]
    public virtual SolicitacaoIntervencaoStatus SolicitacaoIntervencaoStatus { get; set; } = null!;

    [ForeignKey("TipoSolicitacaoIntervencaoId")]
    [InverseProperty("SolicitacaoIntervencaos")]
    public virtual TipoSolicitacaoIntervencao TipoSolicitacaoIntervencao { get; set; } = null!;
}
