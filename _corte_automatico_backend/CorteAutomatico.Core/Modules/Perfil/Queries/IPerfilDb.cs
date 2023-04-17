using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.Perfil.Dtos;

namespace CorteAutomatico.Core.Modules.Perfil.Queries;

public interface IPerfilDb
{
    Task<PerfilDto?> FindByUuidAsync(Guid uuid);
    Task<IEnumerable<PerfilDto>> FindAllAsync();
    Task<IEnumerable<PerfilDto>> FindAllAsync(Search search);
    Task<PaginatedList<PerfilDto>> FindAllAsync(Pagination pagination);
    Task<PaginatedList<PerfilDto>> FindAllAsync(Pagination pagination, Search search);
}