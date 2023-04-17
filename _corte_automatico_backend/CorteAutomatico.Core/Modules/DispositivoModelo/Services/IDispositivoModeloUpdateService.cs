using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;

namespace CorteAutomatico.Core.Modules.DispositivoModelo.Services;

public interface IDispositivoModeloUpdateService
{
    public Task<DispositivoModeloDto> UpdateAsync(Guid uuid, Command<DispositivoModeloRequestDto> command);
}