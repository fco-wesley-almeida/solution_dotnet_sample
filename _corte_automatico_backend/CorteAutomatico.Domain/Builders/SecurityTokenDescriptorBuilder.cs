using System.Security.Claims;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.Modules.Jwt.Builders;
using Microsoft.IdentityModel.Tokens;

namespace CorteAutomatico.Domain.Builders;

public class SecurityTokenDescriptorBuilder: ISecurityTokenDescriptorBuilder
{
    private ClaimsIdentity? _subject;
    private DateTime? _expires;
    private string? _issuer;
    private string? _audience;
    private SigningCredentials? _signingCredentials;

    public ISecurityTokenDescriptorBuilder SetSubject(ClaimsIdentity subject)
    {
        _subject = subject;
        return this;
    }
    
    public ISecurityTokenDescriptorBuilder SetExpires(DateTime expires)
    {
        _expires = expires;
        return this;
    }
    
    public ISecurityTokenDescriptorBuilder SetIssuer(string? issuer)
    {
        _issuer = issuer;
        return this;
    }
    
    public ISecurityTokenDescriptorBuilder SetAudience(string? audience)
    {
        _audience = audience;
        return this;
    }
    
    public ISecurityTokenDescriptorBuilder SetSigningCredentials(byte[] key, string algorithm)
    {
        _signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature
        );
        return this;
    }

    public SecurityTokenDescriptor Build() =>
        new SecurityTokenDescriptor
        {
            Subject = _subject,
            Expires = _expires,
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = _signingCredentials
        };
}