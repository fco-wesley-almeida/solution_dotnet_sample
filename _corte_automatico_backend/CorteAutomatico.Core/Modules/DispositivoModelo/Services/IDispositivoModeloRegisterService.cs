using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;

namespace CorteAutomatico.Core.Modules.DispositivoModelo.Services;

public interface IDispositivoModeloRegisterService
{
    public Task<DispositivoModeloDto> RegisterAsync(Command<DispositivoModeloRequestDto> command);
}