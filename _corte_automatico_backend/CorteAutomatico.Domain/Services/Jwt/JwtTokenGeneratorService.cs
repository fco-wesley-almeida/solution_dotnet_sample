using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using CorteAutomatico.Core.Modules.Authentication.Dtos;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.Jwt.Builders;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.Jwt.Services;
using CorteAutomatico.Domain.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CorteAutomatico.Domain.Services.Jwt;

public class JwtTokenGeneratorService: IJwtTokenGeneratorService
{
    private readonly byte[] _key;
    private readonly int _refreshTokenValidityInMinutes;
    private readonly int _accessTokenValidityInMinutes;
    private readonly string _audience;
    private readonly string _issuer;
    private readonly ICryptographyService _cryptographyService;
    private readonly IClaimsIdentityBuilder _claimsIdentityBuilder;
    private readonly IJwtTokenBuilder _jwtTokenBuilder;
    private readonly ISecurityTokenDescriptorBuilder _securityTokenDescriptorBuilder;
    
    public JwtTokenGeneratorService(
        IConfiguration configuration, 
        ICryptographyService cryptographyService, 
        IClaimsIdentityBuilder claimsIdentityBuilder, 
        IJwtTokenBuilder jwtTokenBuilder, 
        ISecurityTokenDescriptorBuilder securityTokenDescriptorBuilder
    )
    {
        _cryptographyService = cryptographyService;
        _claimsIdentityBuilder = claimsIdentityBuilder;
        _jwtTokenBuilder = jwtTokenBuilder;
        _securityTokenDescriptorBuilder = securityTokenDescriptorBuilder;
        _key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);
        _refreshTokenValidityInMinutes = Convert.ToInt32(configuration["Jwt:RefreshTokenValidityInMinutes"]);
        _accessTokenValidityInMinutes = Convert.ToInt32(configuration["Jwt:TokenValidityInMinutes"]);
        _audience = configuration["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt:Audience");
        _issuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer");
    }

    public JwtToken GenerateToken(UsuarioWithPasswdDto usuarioWithPasswdDto)
    {
        DateTime refreshTokenExpiration = DateTime.Now.ToUniversalTime().AddMinutes(_refreshTokenValidityInMinutes); 
        string refreshToken = GenerateRefreshToken();
        JwtContext jwtContext = new(
            usuarioWithPasswdDto, 
            refreshToken, 
            refreshTokenExpiration
        );
        return _jwtTokenBuilder
              .SetSecurityTokenDescriptor(SecurityTokenDescriptor(usuarioWithPasswdDto, jwtContext))
              .SetRefreshToken(refreshToken, refreshTokenExpiration)
              .Build();
    }

    private SecurityTokenDescriptor SecurityTokenDescriptor(UsuarioWithPasswdDto usuarioWithPasswdDto, JwtContext jwtContext) =>
        _securityTokenDescriptorBuilder
           .SetAudience(_audience)
           .SetExpires(DateTime.Now.ToUniversalTime().AddMinutes(_accessTokenValidityInMinutes))
           .SetIssuer(_issuer)
           .SetSubject(ClaimsIdentity(usuarioWithPasswdDto, jwtContext))
           .SetSigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature)
           .Build();

    private ClaimsIdentity ClaimsIdentity(UsuarioWithPasswdDto usuarioWithPasswdDto, JwtContext jwtContext) =>
        _claimsIdentityBuilder
           .AddClaim(JwtRegisteredClaimNames.Sub, usuarioWithPasswdDto.Login)
           .AddClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
           .AddClaim("Context", _cryptographyService.Encrypt(jwtContext))
           .Build();

    private string GenerateRefreshToken() => Guid.NewGuid().ToString();
}