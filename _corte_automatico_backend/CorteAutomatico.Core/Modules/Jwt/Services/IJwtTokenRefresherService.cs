using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Jwt.Models;

namespace CorteAutomatico.Core.Modules.Jwt.Services;

public interface IJwtTokenRefresherService
{
    public Task<JwtToken> RefreshTokenAsync(Command<string> command);
}