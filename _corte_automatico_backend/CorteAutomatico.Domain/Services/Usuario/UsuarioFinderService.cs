using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Authentication.Queries;
using CorteAutomatico.Core.Modules.Usuario.Dtos;
using CorteAutomatico.Core.Modules.Usuario.Services;

namespace CorteAutomatico.Domain.Services.Usuario;

public class UsuarioFinderService: IUsuarioFinderService
{
    private readonly IUsuarioDb _usuarioDb;

    public UsuarioFinderService(IUsuarioDb usuarioDb)
    {
        _usuarioDb = usuarioDb;
    }

    public async Task<PaginatedList<UsuarioDto>> FindAllAsync(Command<(Pagination?, Search?)> command)
    {
        Pagination? pagination = command.Data.Item1;
        Search? search = command.Data.Item2;
        return pagination switch
        {
            not null when search is not null => await _usuarioDb.FindAllAsync(pagination, search),
            not null when search is null => await _usuarioDb.FindAllAsync(pagination),
            null when search is not null => new(await _usuarioDb.FindAllAsync(search)),
            _ => new(await _usuarioDb.FindAllAsync()),
        };
    }

    public async Task<UsuarioDto> FindByUuid(Command<Guid> command)
    {
        return await _usuarioDb.FindByUuid(command.Data) ?? throw new NotFoundException();
    }
}