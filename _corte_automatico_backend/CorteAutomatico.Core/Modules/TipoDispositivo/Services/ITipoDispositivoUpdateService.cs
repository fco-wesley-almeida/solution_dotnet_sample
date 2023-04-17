using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;

namespace CorteAutomatico.Core.Modules.TipoDispositivo.Services;

public interface ITipoDispositivoUpdateService
{
    public Task<TipoDispositivoDto> UpdateAsync(Guid uuid, Command<TipoDispositivoRequestDto> command);
}