using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("confirmacao_email")]
[Index("Uuid", Name = "uk_confirmacao_email_uuid", IsUnique = true)]
public partial class ConfirmacaoEmail: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("usuario_id")]
    public int UsuarioId { get; set; }

    [Column("confirmado")]
    public bool Confirmado { get; set; }

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

    [Column("expira_em", TypeName = "timestamp without time zone")]
    public DateTime ExpiraEm { get; set; }

    [ForeignKey("UsuarioId")]
    [InverseProperty("ConfirmacaoEmails")]
    public virtual Usuario Usuario { get; set; } = null!;
}
