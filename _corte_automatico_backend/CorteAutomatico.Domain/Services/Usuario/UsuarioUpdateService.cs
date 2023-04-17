using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Authentication.Queries;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.Usuario.Dtos;
using CorteAutomatico.Core.Modules.Usuario.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.Usuario;

public class UsuarioUpdateService: IUsuarioUpdateService
{
    private readonly IRepository _repository;
    private readonly IUsuarioDb _usuarioDb;

    public UsuarioUpdateService(IRepository repository, IUsuarioDb usuarioDb)
    {
        _repository = repository;
        _usuarioDb = usuarioDb;
    }

    public async Task<UsuarioDto> UpdateAsync(Guid uuid, Command<UsuarioRequestDto> command)
    {
        var usuario = await _repository.FindByUuidAsync<Core.Entities.Usuario>(uuid) 
                              ?? throw new NotFoundException();
        usuario.MapForUpdate(command);
        await _repository.UpdateAsync(usuario);
        return (await _usuarioDb.FindByUuid(uuid))!;
    }
}