using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Perfil.Dtos;

namespace CorteAutomatico.Core.Modules.Perfil.Services;

public interface IPerfilUpdateService
{
    public Task<PerfilDto> UpdateAsync(Guid uuid, Command<PerfilRequestDto> command);
}