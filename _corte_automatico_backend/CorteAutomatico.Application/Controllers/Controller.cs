using System.Security.Claims;
using System.Text.Json;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.Jwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorteAutomatico.Application.Controllers;

[ApiController]
[Authorize]
[Route($"[controller]")]
public class Controller: ControllerBase
{
    private readonly ICryptographyService _cryptographyService;

    public Controller(ICryptographyService cryptographyService)
    {
        _cryptographyService = cryptographyService;
    }

    protected JwtContext JwtContext()
    {
        Claim claim = HttpContext.User.Claims.First(x => x.Type == "Context");
        var payload = _cryptographyService.Decrypt<JwtContext>(claim.Value);
        return payload ?? throw new InvalidOperationException("JwtContext is null");
    }
}