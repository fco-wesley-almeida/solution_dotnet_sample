using System.Security.Claims;
using CorteAutomatico.Core.ApplicationModels;

namespace CorteAutomatico.Core.Modules.Jwt.Builders;

public interface IClaimsIdentityBuilder: IBuilder<ClaimsIdentity>
{
    IClaimsIdentityBuilder AddClaim(string type, string value);
}