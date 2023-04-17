using System.IdentityModel.Tokens.Jwt;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Modules.TipoDispositivo.Services;

public interface ITipoDispositivoFinderService
{
    public Task<PaginatedList<TipoDispositivoDto>> FindAllAsync(Command<(Pagination?, Search?)> command);
    public Task<TipoDispositivoDto> FindByUuid(Command<Guid> command);
}