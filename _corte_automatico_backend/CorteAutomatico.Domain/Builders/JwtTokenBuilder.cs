using System.IdentityModel.Tokens.Jwt;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.Modules.Jwt.Builders;
using CorteAutomatico.Core.Modules.Jwt.Models;
using Microsoft.IdentityModel.Tokens;

namespace CorteAutomatico.Domain.Builders;

public class JwtTokenBuilder: IJwtTokenBuilder
{
    private SecurityTokenDescriptor? _securityTokenDescriptor;
    private string? _refreshToken;
    private DateTime? _refreshTokenExpirationTime;
    public IJwtTokenBuilder SetSecurityTokenDescriptor(SecurityTokenDescriptor securityTokenDescriptor)
    {
        _securityTokenDescriptor = securityTokenDescriptor;
        return this;
    }

    public IJwtTokenBuilder SetRefreshToken(string refreshToken, DateTime refreshTokenExpirationTime)
    {
        _refreshToken = refreshToken;
        _refreshTokenExpirationTime = refreshTokenExpirationTime;
        return this;
    }
    public JwtToken Build()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(_securityTokenDescriptor);
        return new(
            tokenHandler.WriteToken(token), 
            _refreshToken!, 
             _refreshTokenExpirationTime ?? throw new ArgumentNullException(nameof(_refreshTokenExpirationTime)),
            _securityTokenDescriptor?.Expires ?? throw new ArgumentNullException(nameof(_securityTokenDescriptor.Expires))
        );
    }
}