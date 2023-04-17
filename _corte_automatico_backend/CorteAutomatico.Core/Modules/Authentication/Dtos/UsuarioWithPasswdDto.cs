namespace CorteAutomatico.Core.Modules.Authentication.Dtos;

public class UsuarioWithPasswdDto
{
    public int Id { get; set; }
    public Guid Uuid { get; set; }
    public string Login { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public int PerfilId { get; set; }
    public DateTime DataExpiracaoSenha { get; set; }

    public bool PasswordIsExpired() => DateTime.Now > DataExpiracaoSenha;
}