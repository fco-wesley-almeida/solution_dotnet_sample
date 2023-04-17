using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Authentication.Queries;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.Jwt.Services;

namespace CorteAutomatico.Domain.Services.Jwt;

public class JwtTokenRefresherService: IJwtTokenRefresherService
{
    private readonly IUsuarioDb _usuarioDb;
    private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;

    public JwtTokenRefresherService(IUsuarioDb usuarioDb, IJwtTokenGeneratorService jwtTokenGeneratorService)
    {
        _usuarioDb = usuarioDb;
        _jwtTokenGeneratorService = jwtTokenGeneratorService;
    }

    public async Task<JwtToken> RefreshTokenAsync(Command<string> command)
    {
        string refreshToken = command.Data;
        if (refreshToken != command.JwtContext.RefreshToken)
        {
            throw new BadRequestException("RefreshToken inválido.");
        }
        if (command.JwtContext.RefreshTokenExpiration < DateTime.Now.ToUniversalTime())
        {
            throw new BadRequestException("RefreshToken expirado.");
        }
        var usuarioDto = await _usuarioDb.FindByIdAsync(command.JwtContext.UsuarioId);
        return _jwtTokenGeneratorService.GenerateToken(usuarioDto!);
    }
}