using CorteAutomatico.Core.Entities;

namespace CorteAutomatico.Core.Modules.Usuario.Dtos;

public class UsuarioDto
{
    public Guid Uuid { get; set; }
    public string Nome { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string PerfilNome { get; set; } = null!;
    public Guid PerfilUuid { get; set; }
    public bool EmailConfirmado { get; set; }
    public string CriadoPor { get; set; } = null!;
    public DateTime CriadoEm { get; set; }
    public string ModificadoPor { get; set; } = null!;
    public DateTime ModificadoEm { get; set; }
    public bool Ativo { get; set; }
}