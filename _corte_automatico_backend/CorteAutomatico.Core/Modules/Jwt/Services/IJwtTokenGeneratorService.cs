using CorteAutomatico.Core.Modules.Authentication.Dtos;
using CorteAutomatico.Core.Modules.Jwt.Models;

namespace CorteAutomatico.Core.Modules.Jwt.Services;

public interface IJwtTokenGeneratorService
{
    JwtToken GenerateToken(UsuarioWithPasswdDto usuarioWithPasswdDto);
}