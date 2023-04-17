using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Authentication.Dtos;
using CorteAutomatico.Core.Modules.Authentication.Queries;
using CorteAutomatico.Core.Modules.Authentication.Services;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.Jwt.Services;

namespace CorteAutomatico.Domain.Services.Authentication;

public class LoginService: ILoginService
{
    private readonly IUsuarioDb _usuarioDb;
    private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService; 

    public LoginService(IUsuarioDb usuarioDb, IJwtTokenGeneratorService jwtTokenGeneratorService)
    {
        _usuarioDb = usuarioDb;
        _jwtTokenGeneratorService = jwtTokenGeneratorService;
    }

    public async Task<JwtToken> LoginAsync(LoginRequest loginRequest)
    {
        var usuarioDto = await _usuarioDb.FindByLoginAsync(loginRequest.Login) 
                      ?? throw new UnauthorizedException();
        if (usuarioDto.PasswordIsExpired() || usuarioDto.Senha != loginRequest.Password)
        {
            throw new UnauthorizedException();
        }
        return _jwtTokenGeneratorService.GenerateToken(usuarioDto);
    }
}