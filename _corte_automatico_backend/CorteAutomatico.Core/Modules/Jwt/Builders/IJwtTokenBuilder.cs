using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.Modules.Jwt.Models;
using Microsoft.IdentityModel.Tokens;

namespace CorteAutomatico.Core.Modules.Jwt.Builders;

public interface IJwtTokenBuilder: IBuilder<JwtToken>
{
    IJwtTokenBuilder SetSecurityTokenDescriptor(SecurityTokenDescriptor securityTokenDescriptor);
    IJwtTokenBuilder SetRefreshToken(string refreshToken, DateTime refreshTokenExpirationTime);
}