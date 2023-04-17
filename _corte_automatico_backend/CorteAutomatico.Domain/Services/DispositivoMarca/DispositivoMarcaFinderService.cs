using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;
using CorteAutomatico.Core.Modules.DispositivoMarca.Queries;
using CorteAutomatico.Core.Modules.DispositivoMarca.Services;

namespace CorteAutomatico.Domain.Services.DispositivoMarca;

public class DispositivoMarcaFinderService: IDispositivoMarcaFinderService
{
    private readonly IDispositivoMarcaDb _dispositivoMarcaDb;
    
    public DispositivoMarcaFinderService(IDispositivoMarcaDb dispositivoMarcaDb)
    {
        _dispositivoMarcaDb = dispositivoMarcaDb;
    }
    
    public async Task<PaginatedList<DispositivoMarcaDto>> FindAllAsync(Command<(Pagination?, Search?, DispositivoMarcaFilter?)> command)
    {
        Pagination? pagination = command.Data.Item1;
        DispositivoMarcaFilter? filter = command.Data.Item3;
        Search? search = filter is not null ? null : command.Data.Item2;
        return pagination switch
        {
            not null when search is not null => await _dispositivoMarcaDb.FindAllAsync(pagination, search),
            not null when search is null && filter is null => await _dispositivoMarcaDb.FindAllAsync(pagination),
            not null when filter is not null => await _dispositivoMarcaDb.FindByTipoDispositivoUuidAsync(pagination, filter.TipoDispositivoUuid),
            null when filter is not null => new(await _dispositivoMarcaDb.FindByTipoDispositivoUuidAsync(filter.TipoDispositivoUuid)),
            null when search is not null => new(await _dispositivoMarcaDb.FindAllAsync(search)),
            _ => new(await _dispositivoMarcaDb.FindAllAsync()),
        };
    }

    public async Task<DispositivoMarcaDto> FindByUuid(Command<Guid> command)
    {
        return await _dispositivoMarcaDb.FindByUuid(command.Data) ?? throw new NotFoundException();
    }
}