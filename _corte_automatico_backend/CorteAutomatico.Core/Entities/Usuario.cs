using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("usuario")]
[Index("Uuid", Name = "uk_usuario_uuid", IsUnique = true)]
public partial class Usuario: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("login")]
    [StringLength(100)]
    public string Login { get; set; } = null!;

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

    [Column("perfil_id")]
    public int PerfilId { get; set; }

    [Column("cpf")]
    [StringLength(100)]
    public string Cpf { get; set; } = null!;

    [Column("email_confirmado")]
    public bool EmailConfirmado { get; set; }

    [Column("email_confirmacao_token")]
    [StringLength(100)]
    public string? EmailConfirmacaoToken { get; set; }

    [Column("email_confirmacao_expira_em", TypeName = "timestamp without time zone")]
    public DateTime? EmailConfirmacaoExpiraEm { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<ColaboradorFinanciadora> ColaboradorFinanciadoras { get; } = new List<ColaboradorFinanciadora>();

    [InverseProperty("Usuario")]
    public virtual ICollection<ColaboradorIntegrador> ColaboradorIntegradors { get; } = new List<ColaboradorIntegrador>();

    [ForeignKey("PerfilId")]
    [InverseProperty("Usuarios")]
    public virtual Perfil Perfil { get; set; } = null!;

    [InverseProperty("Usuario")]
    public virtual ICollection<UsuarioSenha> UsuarioSenhas { get; } = new List<UsuarioSenha>();
}
