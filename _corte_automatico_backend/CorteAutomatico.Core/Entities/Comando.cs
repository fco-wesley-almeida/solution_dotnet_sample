using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("comando")]
[Index("Uuid", Name = "uk_comando_uuid", IsUnique = true)]
public partial class Comando: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("dispositivo_id")]
    public int DispositivoId { get; set; }

    [Column("numero_destinatario")]
    [StringLength(100)]
    public string NumeroDestinatario { get; set; } = null!;

    [Column("msg")]
    [StringLength(100)]
    public string Msg { get; set; } = null!;

    [Column("situacao_envio")]
    [StringLength(100)]
    public string? SituacaoEnvio { get; set; }

    [Column("situacao_mensagem")]
    [StringLength(100)]
    public string? SituacaoMensagem { get; set; }

    [Column("id_mensagem")]
    [StringLength(100)]
    public string IdMensagem { get; set; } = null!;

    [Column("codigo_erro")]
    [StringLength(100)]
    public string? CodigoErro { get; set; }

    [Column("data_agendamento_envio")]
    public DateOnly? DataAgendamentoEnvio { get; set; }

    [Column("hora_agendamento_envio")]
    public TimeOnly? HoraAgendamentoEnvio { get; set; }

    [Column("numero_resposta")]
    [StringLength(100)]
    public string? NumeroResposta { get; set; }

    [Column("id_resposta")]
    [StringLength(100)]
    public string? IdResposta { get; set; }

    [Column("texto_resposta")]
    [StringLength(100)]
    public string? TextoResposta { get; set; }

    [Column("qtd_creditos_consumidos")]
    public int? QtdCreditosConsumidos { get; set; }

    [Column("operadora")]
    [StringLength(100)]
    public string? Operadora { get; set; }

    [Column("criado_em", TypeName = "timestamp without time zone")]
    public DateTime CriadoEm { get; set; }

    [Column("modificado_por")]
    [StringLength(100)]
    public string ModificadoPor { get; set; } = null!;

    [Column("modificado_em", TypeName = "timestamp without time zone")]
    public DateTime ModificadoEm { get; set; }

    [Column("ativo")]
    public bool Ativo { get; set; }

    [Column("tipo_comando_id")]
    public int TipoComandoId { get; set; }

    [Column("criado_por")]
    [StringLength(100)]
    public string CriadoPor { get; set; } = null!;

    [ForeignKey("DispositivoId")]
    [InverseProperty("Comandos")]
    public virtual Dispositivo Dispositivo { get; set; } = null!;

    [ForeignKey("TipoComandoId")]
    [InverseProperty("Comandos")]
    public virtual TipoComando TipoComando { get; set; } = null!;
}
