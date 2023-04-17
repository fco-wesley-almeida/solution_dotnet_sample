using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.Authentication.Dtos;
using CorteAutomatico.Core.Modules.Usuario.Dtos;

namespace CorteAutomatico.Core.Modules.Authentication.Queries;

public interface IUsuarioDb
{
    Task<UsuarioWithPasswdDto?> FindByLoginAsync(string login);
    Task<UsuarioWithPasswdDto?> FindByIdAsync(int usuarioId);
    Task<UsuarioDto?> FindByUuid(Guid uuid);
    Task<IEnumerable<UsuarioDto>> FindAllAsync();
    Task<IEnumerable<UsuarioDto>> FindAllAsync(Search search);
    Task<PaginatedList<UsuarioDto>> FindAllAsync(Pagination pagination);
    Task<PaginatedList<UsuarioDto>> FindAllAsync(Pagination pagination, Search search);
    Task<bool> ExistsWithSameLoginAsync(string login);
    Task<bool> ExistsWithSameEmailAsync(string email);
    Task<bool> ExistsWithSameCpfAsync(string cpf);
}