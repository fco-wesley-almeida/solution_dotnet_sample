using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Attributes;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.Perfil.Dtos;
using CorteAutomatico.Core.Modules.Perfil.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorteAutomatico.Application.Controllers;

public class PerfilController : Controller
{
    private readonly IPerfilFinderService _perfilFinderService;
    private readonly IPerfilRegisterService _perfilRegisterService;
    private readonly IPerfilUpdateService _perfilUpdateService;

    public PerfilController(
        IPerfilFinderService perfilFinderService,
        IPerfilRegisterService perfilRegisterService,
        IPerfilUpdateService perfilUpdateService,
        ICryptographyService cryptographyService
    ) : base(cryptographyService)
    {
        _perfilFinderService = perfilFinderService;
        _perfilRegisterService = perfilRegisterService;
        _perfilUpdateService = perfilUpdateService;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<PerfilDto>>> FindAllAsync([SearchLength] string? search = null,
        int? page = null, int? perPage = null)
    {
        (Pagination?, Search?) searchCriteria = new(
            Pagination.Builder()
                .SetPage(page)
                .SetPerPage(perPage)
                .Build(),
            search is not null ? new Search(search) : null
        );
        var perfis = await _perfilFinderService.FindAllAsync(
            Command<(Pagination?, Search?)>
                .Builder()
                .SetData(searchCriteria)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(perfis);
    }
    
    [HttpGet("{uuid:guid}")]
    public async Task<ActionResult<JwtToken>> FindByUuidAsync(Guid uuid)
    {
        var perfil = await _perfilFinderService.FindByUuid(
            Command<Guid>
                .Builder()
                .SetData(uuid)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(perfil);
    }

    [HttpPost]
    public async Task<ActionResult<JwtToken>> RegisterAsync(PerfilRequestDto request)
    {
        var perfil = await _perfilRegisterService.RegisterAsync(
            Command<PerfilRequestDto>
                .Builder()
                .SetData(request)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(perfil);
    }

    [HttpPut("{uuid:guid}")]
    public async Task<ActionResult<JwtToken>> UpdateAsync(Guid uuid, PerfilRequestDto request)
    {
        var command = Command<PerfilRequestDto>
            .Builder()
            .SetData(request)
            .SetJwtContext(JwtContext())
            .Build();
        var perfil = await _perfilUpdateService.UpdateAsync(uuid, command);
        return Ok(perfil);
    }
}