using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Perfil.Dtos;

namespace CorteAutomatico.Core.Modules.Perfil.Services;

public interface IPerfilRegisterService
{
    public Task<PerfilDto> RegisterAsync(Command<PerfilRequestDto> command);
}