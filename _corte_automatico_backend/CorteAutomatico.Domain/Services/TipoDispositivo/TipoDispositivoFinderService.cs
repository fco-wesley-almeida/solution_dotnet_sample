using System.IdentityModel.Tokens.Jwt;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using CorteAutomatico.Core.Modules.TipoDispositivo.Services;

namespace CorteAutomatico.Domain.Services.TipoDispositivo;

public class TipoDispositivoFinderService: ITipoDispositivoFinderService
{
    private readonly ITipoDispositivoDb _tipoDispositivoDb;

    public TipoDispositivoFinderService(ITipoDispositivoDb tipoDispositivoDb)
    {
        _tipoDispositivoDb = tipoDispositivoDb;
    }

    public async Task<PaginatedList<TipoDispositivoDto>> FindAllAsync(Command<(Pagination?, Search?)> command)
    {
        Pagination? pagination = command.Data.Item1;
        Search? search = command.Data.Item2;
        return pagination switch
        {
            not null when search is not null => await _tipoDispositivoDb.FindAllAsync(pagination, search),
            not null when search is null => await _tipoDispositivoDb.FindAllAsync(pagination),
            null when search is not null => new(await _tipoDispositivoDb.FindAllAsync(search)),
            _ => new(await _tipoDispositivoDb.FindAllAsync()),
        };
    }

    public async Task<TipoDispositivoDto> FindByUuid(Command<Guid> command)
    {
        return await _tipoDispositivoDb.FindByUuidAsync(command.Data) ?? throw new NotFoundException();
    }
}