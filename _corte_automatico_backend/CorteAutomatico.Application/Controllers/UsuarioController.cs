using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Attributes;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.Usuario.Dtos;
using CorteAutomatico.Core.Modules.Usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorteAutomatico.Application.Controllers;

public class UsuarioController: Controller
{
    private readonly IUsuarioFinderService _usuarioFinderService;
    private readonly IUsuarioRegisterService _usuarioRegisterService;
    private readonly IUsuarioUpdateService _usuarioUpdateService;
    
    public UsuarioController(
        IUsuarioFinderService usuarioFinderService, 
        IUsuarioRegisterService usuarioRegisterService, 
        IUsuarioUpdateService usuarioUpdateService,
        ICryptographyService cryptographyService
    ): base(cryptographyService)
    {
        _usuarioFinderService = usuarioFinderService;
        _usuarioRegisterService = usuarioRegisterService;
        _usuarioUpdateService = usuarioUpdateService;
    }

    
    [HttpGet]
    public async Task<ActionResult<PaginatedList<UsuarioDto>>> FindAllAsync([SearchLength] string? search = null, int? page = null, int? perPage = null)
    {
        (Pagination?, Search?) searchCriteria = new(
            Pagination.Builder()
                .SetPage(page)
                .SetPerPage(perPage)
                .Build(),
            search is not null ? new Search(search) : null
        );
        var usuarios = await _usuarioFinderService.FindAllAsync(
            Command<(Pagination?, Search?)>
                .Builder()
                .SetData(searchCriteria)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(usuarios);
    }
    [HttpGet("{uuid:guid}")]
    public async Task<ActionResult<JwtToken>> FindByUuidAsync(Guid uuid)
    {
        var usuario = await _usuarioFinderService.FindByUuid(
            Command<Guid>
               .Builder()
               .SetData(uuid)
               .SetJwtContext(JwtContext())
               .Build()
        );
        return Ok(usuario);
    }
    
    [HttpPost]
    public async Task<ActionResult<JwtToken>> RegisterAsync(UsuarioRequestDto request)
    {
        var usuario = await _usuarioRegisterService.RegisterAsync(
            Command<UsuarioRequestDto>
               .Builder()
               .SetData(request)
               .SetJwtContext(JwtContext())
               .Build()
        );
        return Ok(usuario);
    }
    
    [HttpPut("{uuid:guid}")]
    public async Task<ActionResult<JwtToken>> UpdateAsync(Guid uuid, UsuarioRequestDto request)
    {
        var command = Command<UsuarioRequestDto>
                     .Builder()
                     .SetData(request)
                     .SetJwtContext(JwtContext())
                     .Build();
        var usuario = await _usuarioUpdateService.UpdateAsync(uuid, command);
        return Ok(usuario);
    }
}