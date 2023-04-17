using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;

namespace CorteAutomatico.Core.Modules.DispositivoMarca.Services;

public interface IDispositivoMarcaFinderService
{
    public Task<PaginatedList<DispositivoMarcaDto>> FindAllAsync(Command<(Pagination?, Search?, DispositivoMarcaFilter?)> command);
    public Task<DispositivoMarcaDto> FindByUuid(Command<Guid> command);
}