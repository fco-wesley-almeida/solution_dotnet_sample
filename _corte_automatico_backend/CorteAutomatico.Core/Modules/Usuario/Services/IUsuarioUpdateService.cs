using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Usuario.Dtos;

namespace CorteAutomatico.Core.Modules.Usuario.Services;

public interface IUsuarioUpdateService
{
    public Task<UsuarioDto> UpdateAsync(Guid uuid, Command<UsuarioRequestDto> command);
}