using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;

namespace CorteAutomatico.Core.Modules.DispositivoModelo.Services;

public interface IDispositivoModeloFinderService
{
    public Task<PaginatedList<DispositivoModeloDto>> FindAllAsync(Command<(Pagination?, Search?)> command);
    public Task<DispositivoModeloDto> FindByUuid(Command<Guid> command);
}