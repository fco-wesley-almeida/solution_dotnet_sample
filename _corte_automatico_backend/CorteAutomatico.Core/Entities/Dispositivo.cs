using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("dispositivo")]
[Index("Uuid", Name = "uk_dispositivo_uuid", IsUnique = true)]
public partial class Dispositivo: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("serial")]
    [StringLength(100)]
    public string Serial { get; set; } = null!;

    [Column("numero_sms")]
    [StringLength(100)]
    public string NumeroSms { get; set; } = null!;

    [Column("validado")]
    public bool Validado { get; set; }

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

    [Column("dispositivo_modelo_id")]
    public int DispositivoModeloId { get; set; }

    [InverseProperty("Dispositivo")]
    public virtual ICollection<Comando> Comandos { get; } = new List<Comando>();

    [InverseProperty("Dispositivo")]
    public virtual ICollection<DispositivoInstalacao> DispositivoInstalacaos { get; } = new List<DispositivoInstalacao>();

    [ForeignKey("DispositivoModeloId")]
    [InverseProperty("Dispositivos")]
    public virtual DispositivoModelo DispositivoModelo { get; set; } = null!;
}
