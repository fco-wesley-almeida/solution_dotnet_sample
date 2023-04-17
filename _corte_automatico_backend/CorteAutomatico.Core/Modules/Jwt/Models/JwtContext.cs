using CorteAutomatico.Core.Modules.Authentication.Dtos;

namespace CorteAutomatico.Core.Modules.Jwt.Models;

public class JwtContext
{
    public JwtContext()
    {
    }
    public JwtContext(UsuarioWithPasswdDto usuarioWithPasswdDto, string refreshToken, DateTime refreshTokenExpiration)
    {
        UsuarioId = usuarioWithPasswdDto.Id;
        UsuarioUuid = usuarioWithPasswdDto.Uuid;
        Login = usuarioWithPasswdDto.Login ?? throw new ArgumentNullException(nameof(usuarioWithPasswdDto.Login));
        PerfilId = usuarioWithPasswdDto.PerfilId;
        RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        RefreshTokenExpiration = refreshTokenExpiration;
    }

    public int UsuarioId { get; set; }
    public Guid UsuarioUuid { get; set; }
    public string Login { get; set; } = null!;
    public int PerfilId {get; set; }
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpiration { get; set; }
}