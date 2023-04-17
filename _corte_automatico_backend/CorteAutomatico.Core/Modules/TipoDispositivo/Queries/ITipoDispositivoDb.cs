using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;

namespace CorteAutomatico.Core.Modules.TipoDispositivo.Queries;

public interface ITipoDispositivoDb
{
    Task<TipoDispositivoDto?> FindByUuidAsync(Guid uuid);
    Task<IEnumerable<TipoDispositivoDto>> FindAllAsync();
    Task<IEnumerable<TipoDispositivoDto>> FindAllAsync(Search search);
    Task<PaginatedList<TipoDispositivoDto>> FindAllAsync(Pagination pagination);
    Task<PaginatedList<TipoDispositivoDto>> FindAllAsync(Pagination pagination, Search search);
}