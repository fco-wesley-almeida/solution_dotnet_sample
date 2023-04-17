using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Attributes;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorteAutomatico.Application.Controllers;

public class TipoDispositivoController: Controller
{
    private readonly ITipoDispositivoFinderService _tipoDispositivoFinderService;
    private readonly ITipoDispositivoRegisterService _tipoDispositivoRegisterService;
    private readonly ITipoDispositivoUpdateService _tipoDispositivoUpdateService;
    public TipoDispositivoController(
        ITipoDispositivoFinderService tipoDispositivoFinderService, 
        ITipoDispositivoRegisterService tipoDispositivoRegisterService, 
        ITipoDispositivoUpdateService tipoDispositivoUpdateService,
        ICryptographyService cryptographyService
    ): base(cryptographyService)
    {
        _tipoDispositivoFinderService = tipoDispositivoFinderService;
        _tipoDispositivoRegisterService = tipoDispositivoRegisterService;
        _tipoDispositivoUpdateService = tipoDispositivoUpdateService;
    }

    
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TipoDispositivoDto>>> FindAllAsync([SearchLength] string? search = null, int? page = null, int? perPage = null)
    {
        (Pagination?, Search?) searchCriteria = new(
            Pagination.Builder()
                .SetPage(page)
                .SetPerPage(perPage)
                .Build(),
            search is not null ? new Search(search) : null
        );
        var tipoDispositivos = await _tipoDispositivoFinderService.FindAllAsync(
            Command<(Pagination?, Search?)>
                .Builder()
                .SetData(searchCriteria)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(tipoDispositivos);
    }
    [HttpGet("{uuid:guid}")]
    public async Task<ActionResult<JwtToken>> FindByUuidAsync(Guid uuid)
    {
        var tipoDispositivo = await _tipoDispositivoFinderService.FindByUuid(
            Command<Guid>
               .Builder()
               .SetData(uuid)
               .SetJwtContext(JwtContext())
               .Build()
        );
        return Ok(tipoDispositivo);
    }
    
    [HttpPost]
    public async Task<ActionResult<JwtToken>> RegisterAsync(TipoDispositivoRequestDto request)
    {
        var tipoDispositivo = await _tipoDispositivoRegisterService.RegisterAsync(
            Command<TipoDispositivoRequestDto>
               .Builder()
               .SetData(request)
               .SetJwtContext(JwtContext())
               .Build()
        );
        return Ok(tipoDispositivo);
    }
    
    [HttpPut("{uuid:guid}")]
    public async Task<ActionResult<JwtToken>> UpdateAsync(Guid uuid, TipoDispositivoRequestDto request)
    {
        var command = Command<TipoDispositivoRequestDto>
                     .Builder()
                     .SetData(request)
                     .SetJwtContext(JwtContext())
                     .Build();
        var tipoDispositivo = await _tipoDispositivoUpdateService.UpdateAsync(uuid, command);
        return Ok(tipoDispositivo);
    }
}