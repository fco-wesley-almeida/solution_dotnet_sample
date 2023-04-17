using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;

namespace CorteAutomatico.Core.Modules.DispositivoMarca.Queries;

public interface IDispositivoMarcaDb
{
    Task<DispositivoMarcaDto?> FindByUuid(Guid uuid);
    Task<IEnumerable<DispositivoMarcaDto>> FindAllAsync();
    Task<IEnumerable<DispositivoMarcaDto>> FindAllAsync(Search search);
    Task<PaginatedList<DispositivoMarcaDto>> FindAllAsync(Pagination pagination);
    Task<PaginatedList<DispositivoMarcaDto>> FindAllAsync(Pagination pagination, Search search);
    Task<PaginatedList<DispositivoMarcaDto>> FindByTipoDispositivoUuidAsync(Pagination pagination, Guid tipoDispositivoUuid);
    Task<IEnumerable<DispositivoMarcaDto>> FindByTipoDispositivoUuidAsync(Guid tipoDispositivoUuid);
}