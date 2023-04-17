using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;

namespace CorteAutomatico.Core.Modules.DispositivoMarca.Services;

public interface IDispositivoMarcaRegisterService
{
    public Task<DispositivoMarcaDto> RegisterAsync(Command<DispositivoMarcaRequestDto> command);
}