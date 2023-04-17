using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.Authentication.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.Usuario.Dtos;

namespace CorteAutomatico.Core.Modules.Usuario.Services;

public interface IUsuarioFinderService
{
    public Task<PaginatedList<UsuarioDto>> FindAllAsync(Command<(Pagination?, Search?)> command);
    public Task<UsuarioDto> FindByUuid(Command<Guid> command);
}