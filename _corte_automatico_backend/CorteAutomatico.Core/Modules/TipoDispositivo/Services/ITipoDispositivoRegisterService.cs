using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;

namespace CorteAutomatico.Core.Modules.TipoDispositivo.Services;

public interface ITipoDispositivoRegisterService
{
    public Task<TipoDispositivoDto> RegisterAsync(Command<TipoDispositivoRequestDto> command);
}