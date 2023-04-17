using System.Security.Claims;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.Modules.Jwt.Builders;

namespace CorteAutomatico.Domain.Builders;

public class ClaimsIdentityBuilder: IClaimsIdentityBuilder
{
    private readonly List<Claim> _claims;

    public ClaimsIdentityBuilder()
    {
        _claims = new();
    }

    public IClaimsIdentityBuilder AddClaim(string type, string value)
    {
        _claims.Add(new Claim(type, value));
        return this;
    }

    public ClaimsIdentity Build() => new ClaimsIdentity(_claims);
}