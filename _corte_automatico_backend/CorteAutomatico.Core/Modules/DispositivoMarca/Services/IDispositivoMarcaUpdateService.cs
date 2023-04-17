using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;

namespace CorteAutomatico.Core.Modules.DispositivoMarca.Services;

public interface IDispositivoMarcaUpdateService
{
    public Task<DispositivoMarcaDto> UpdateAsync(Guid uuid,Command<DispositivoMarcaRequestDto> command);
}