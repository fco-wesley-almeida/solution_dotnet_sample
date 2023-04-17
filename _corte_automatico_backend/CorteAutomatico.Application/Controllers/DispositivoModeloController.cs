using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Attributes;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;
using CorteAutomatico.Core.Modules.DispositivoModelo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorteAutomatico.Application.Controllers;

public class DispositivoModeloController : Controller
{
    private readonly IDispositivoModeloFinderService _dispositivoModeloFinderService;
    private readonly IDispositivoModeloRegisterService _dispositivoModeloRegisterService;
    private readonly IDispositivoModeloUpdateService _dispositivoModeloUpdateService;

    public DispositivoModeloController(
        IDispositivoModeloFinderService dispositivoModeloFinderService,
        IDispositivoModeloRegisterService dispositivoModeloRegisterService,
        IDispositivoModeloUpdateService dispositivoModeloUpdateService,
        ICryptographyService cryptographyService
    ) : base(cryptographyService)
    {
        _dispositivoModeloFinderService = dispositivoModeloFinderService;
        _dispositivoModeloRegisterService = dispositivoModeloRegisterService;
        _dispositivoModeloUpdateService = dispositivoModeloUpdateService;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<DispositivoModeloDto>>> FindAllAsync(
        [SearchLength] string? search = null,
        int? page = null, int? perPage = null)
    {
        (Pagination?, Search?) searchCriteria = new(
            Pagination.Builder()
                .SetPage(page)
                .SetPerPage(perPage)
                .Build(),
            search is not null ? new Search(search) : null
        );
        var dispositivoModelos = await _dispositivoModeloFinderService.FindAllAsync(
            Command<(Pagination?, Search?)>
                .Builder()
                .SetData(searchCriteria)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(dispositivoModelos);
    }

    [HttpGet("{uuid:guid}")]
    public async Task<ActionResult<DispositivoModeloDto>> FindByUuidAsync(Guid uuid)
    {
        var dispositivoModelo = await _dispositivoModeloFinderService.FindByUuid(
            Command<Guid>
                .Builder()
                .SetData(uuid)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(dispositivoModelo);
    }

    [HttpPost]
    public async Task<ActionResult<DispositivoModeloDto>> RegisterAsync(DispositivoModeloRequestDto request)
    {
        var dispositivoModelo = await _dispositivoModeloRegisterService.RegisterAsync(
            Command<DispositivoModeloRequestDto>
                .Builder()
                .SetData(request)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(dispositivoModelo);
    }

    [HttpPut("{uuid:guid}")]
    public async Task<ActionResult<DispositivoModeloDto>> UpdateAsync(Guid uuid, DispositivoModeloRequestDto request)
    {
        var command = Command<DispositivoModeloRequestDto>
            .Builder()
            .SetData(request)
            .SetJwtContext(JwtContext())
            .Build();
        var dispositivoModelo = await _dispositivoModeloUpdateService.UpdateAsync(uuid, command);
        return Ok(dispositivoModelo);
    }
}