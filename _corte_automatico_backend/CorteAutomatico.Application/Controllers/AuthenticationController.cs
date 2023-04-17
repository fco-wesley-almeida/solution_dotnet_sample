using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Authentication.Dtos;
using CorteAutomatico.Core.Modules.Authentication.Services;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.Jwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorteAutomatico.Application.Controllers;

public class AuthenticationController: Controller
{
    private readonly ILoginService _loginService;
    private readonly IJwtTokenRefresherService _jwtTokenRefresherService;

    public AuthenticationController(ILoginService loginService, IJwtTokenRefresherService jwtTokenRefresherService, ICryptographyService cryptographyService) : base(cryptographyService)
    {
        _loginService = loginService;
        _jwtTokenRefresherService = jwtTokenRefresherService;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<ActionResult<JwtToken>> SignInAsync(LoginRequest loginRequest)
    {
        return Ok(await _loginService.LoginAsync(loginRequest));
    }
    
    [HttpPost("refresh-token")]
    public async Task<ActionResult<JwtToken>> RefreshTokenAsync(string refreshToken)
    {
        var command = Command<string>.Builder()
                                     .SetData(refreshToken)
                                     .SetJwtContext(JwtContext())
                                     .Build();
        var jwtToken = await _jwtTokenRefresherService.RefreshTokenAsync(command);
        return Ok(jwtToken);
    }
}