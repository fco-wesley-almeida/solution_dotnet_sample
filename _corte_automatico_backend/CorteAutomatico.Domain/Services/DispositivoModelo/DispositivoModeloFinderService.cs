using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;
using CorteAutomatico.Core.Modules.DispositivoModelo.Queries;
using CorteAutomatico.Core.Modules.DispositivoModelo.Services;

namespace CorteAutomatico.Domain.Services.DispositivoModelo;

public class DispositivoModeloFinderService : IDispositivoModeloFinderService
{
    private readonly IDispositivoModeloDb _dispositivoModeloDb;

    public DispositivoModeloFinderService(IDispositivoModeloDb dispositivoModeloDb)
    {
        _dispositivoModeloDb = dispositivoModeloDb;
    }

    public async Task<PaginatedList<DispositivoModeloDto>> FindAllAsync(Command<(Pagination?, Search?)> command)
    {
        var pagination = command.Data.Item1;
        var search = command.Data.Item2;
        return pagination switch
        {
            not null when search is not null => await _dispositivoModeloDb.FindAllAsync(pagination, search),
            not null when search is null => await _dispositivoModeloDb.FindAllAsync(pagination),
            null when search is not null => new PaginatedList<DispositivoModeloDto>(
                await _dispositivoModeloDb.FindAllAsync(search)),
            _ => new PaginatedList<DispositivoModeloDto>(await _dispositivoModeloDb.FindAllAsync())
        };
    }

    public async Task<DispositivoModeloDto> FindByUuid(Command<Guid> command)
    {
        return await _dispositivoModeloDb.FindByUuid(command.Data) ?? throw new NotFoundException();
    }
}