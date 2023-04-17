using System.Security.Claims;
using CorteAutomatico.Core.ApplicationModels;
using Microsoft.IdentityModel.Tokens;

namespace CorteAutomatico.Core.Modules.Jwt.Builders;

public interface ISecurityTokenDescriptorBuilder: IBuilder<SecurityTokenDescriptor>
{
    ISecurityTokenDescriptorBuilder SetSubject(ClaimsIdentity subject);
    ISecurityTokenDescriptorBuilder SetExpires(DateTime expires);
    ISecurityTokenDescriptorBuilder SetIssuer(string? issuer);
    ISecurityTokenDescriptorBuilder SetAudience(string? audience);
    ISecurityTokenDescriptorBuilder SetSigningCredentials(byte[] key, string algorithm);
}