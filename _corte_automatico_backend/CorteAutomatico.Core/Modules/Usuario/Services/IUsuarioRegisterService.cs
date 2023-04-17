using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Usuario.Dtos;

namespace CorteAutomatico.Core.Modules.Usuario.Services;

public interface IUsuarioRegisterService
{
    public Task<UsuarioDto> RegisterAsync(Command<UsuarioRequestDto> command);
}