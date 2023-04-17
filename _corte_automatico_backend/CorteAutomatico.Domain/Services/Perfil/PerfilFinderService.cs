using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Perfil.Dtos;
using CorteAutomatico.Core.Modules.Perfil.Queries;
using CorteAutomatico.Core.Modules.Perfil.Services;


namespace CorteAutomatico.Domain.Services.Perfil;

public class PerfilFinderService: IPerfilFinderService
{
    private readonly IPerfilDb _perfilDb;
    
    public PerfilFinderService(IPerfilDb perfilDb)
    {
        _perfilDb = perfilDb;
    }
    public async Task<PaginatedList<PerfilDto>> FindAllAsync(Command<(Pagination?, Search?)> command)
    {
        Pagination? pagination = command.Data.Item1;
        Search? search = command.Data.Item2;
        return pagination switch
        {
            not null when search is not null => await _perfilDb.FindAllAsync(pagination, search),
            not null when search is null => await _perfilDb.FindAllAsync(pagination),
            null when search is not null => new(await _perfilDb.FindAllAsync(search)),
            _ => new(await _perfilDb.FindAllAsync()),
        };
    }

    public async  Task<PerfilDto> FindByUuid(Command<Guid> command)
    {
        return await _perfilDb.FindByUuidAsync(command.Data) ?? throw new NotFoundException(); 
    }
}