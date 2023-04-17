using CorteAutomatico.Core.Modules.Authentication.Dtos;
using CorteAutomatico.Core.Modules.Jwt.Models;

namespace CorteAutomatico.Core.Modules.Authentication.Services;

public interface ILoginService
{
    Task<JwtToken> LoginAsync(LoginRequest loginRequest);
}