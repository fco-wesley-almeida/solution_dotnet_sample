using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;

namespace CorteAutomatico.Core.Modules.DispositivoModelo.Queries;

public interface IDispositivoModeloDb
{
    public Task<IEnumerable<DispositivoModeloDto>> FindAllAsync();
    public Task<IEnumerable<DispositivoModeloDto>> FindAllAsync(Search search);
    public Task<PaginatedList<DispositivoModeloDto>> FindAllAsync(Pagination pagination);
    public Task<PaginatedList<DispositivoModeloDto>> FindAllAsync(Pagination pagination, Search search);
    public Task<DispositivoModeloDto?> FindByUuid(Guid uuid);
}