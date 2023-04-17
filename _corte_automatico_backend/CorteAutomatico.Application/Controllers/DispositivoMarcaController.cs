using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Attributes;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;
using CorteAutomatico.Core.Modules.DispositivoMarca.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorteAutomatico.Application.Controllers;

public class DispositivoMarcaController : Controller
{
    private readonly IDispositivoMarcaFinderService _dispositivoMarcaFinderService;
    private readonly IDispositivoMarcaRegisterService _dispositivoMarcaRegisterService;
    private readonly IDispositivoMarcaUpdateService _dispositivoMarcaUpdateService;

    public DispositivoMarcaController(
        IDispositivoMarcaFinderService dispositivoMarcaFinderService,
        IDispositivoMarcaRegisterService dispositivoMarcaRegisterService,
        IDispositivoMarcaUpdateService dispositivoMarcaUpdateService,
        ICryptographyService cryptographyService
    ) : base(cryptographyService)
    {
        _dispositivoMarcaFinderService = dispositivoMarcaFinderService;
        _dispositivoMarcaRegisterService = dispositivoMarcaRegisterService;
        _dispositivoMarcaUpdateService = dispositivoMarcaUpdateService;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<DispositivoMarcaDto>>> FindAllAsync(
        [SearchLength] string? search = null,
        int? page = null, 
        int? perPage = null, 
        Guid? tipoDispositivoUuid = null
    )
    {
        (Pagination?, Search?, DispositivoMarcaFilter?) searchCriteria = new(
            Pagination.Builder()
                .SetPage(page)
                .SetPerPage(perPage)
                .Build(),
            search is not null ? new Search(search) : null,
            tipoDispositivoUuid is not null ? new DispositivoMarcaFilter(tipoDispositivoUuid.Value) : null
        );
        var dispositivoMarcas = await _dispositivoMarcaFinderService.FindAllAsync(
            Command<(Pagination?, Search?, DispositivoMarcaFilter?)>
                .Builder()
                .SetData(searchCriteria)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(dispositivoMarcas);
    }

    [HttpGet("{uuid:guid}")]
    public async Task<ActionResult<DispositivoMarcaDto>> FindByUuidAsync(Guid uuid)
    {
        var dispositivoMarca = await _dispositivoMarcaFinderService.FindByUuid(
            Command<Guid>
                .Builder()
                .SetData(uuid)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(dispositivoMarca);
    }

    [HttpPost]
    public async Task<ActionResult<DispositivoMarcaDto>> RegisterAsync(DispositivoMarcaRequestDto request)
    {
        var dispositivoMarca = await _dispositivoMarcaRegisterService.RegisterAsync(
            Command<DispositivoMarcaRequestDto>
                .Builder()
                .SetData(request)
                .SetJwtContext(JwtContext())
                .Build()
        );
        return Ok(dispositivoMarca);
    }

    [HttpPut("{uuid:guid}")]
    public async Task<ActionResult<DispositivoMarcaDto>> UpdateAsync(Guid uuid, DispositivoMarcaRequestDto request)
    {
        var command = Command<DispositivoMarcaRequestDto>
            .Builder()
            .SetData(request)
            .SetJwtContext(JwtContext())
            .Build();
        var dispositivoMarca = await _dispositivoMarcaUpdateService.UpdateAsync(uuid, command);
        return Ok(dispositivoMarca);
    }
}