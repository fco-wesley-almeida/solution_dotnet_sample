using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.Perfil.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;

namespace CorteAutomatico.Core.Modules.Perfil.Services;

public interface IPerfilFinderService
{
    public Task<PaginatedList<PerfilDto>> FindAllAsync(Command<(Pagination?, Search?)> command);
    public Task<PerfilDto> FindByUuid(Command<Guid> command);
}