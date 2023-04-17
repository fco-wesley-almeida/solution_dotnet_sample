using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Perfil.Dtos;
using CorteAutomatico.Core.Modules.Perfil.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.Perfil;

public class PerfilUpdateService: IPerfilUpdateService
{
    private readonly IRepository _repository;
    
    public PerfilUpdateService( IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<PerfilDto> UpdateAsync(Guid uuid, Command<PerfilRequestDto> command)
    {
        var perfil = await _repository.FindByUuidAsync<Core.Entities.Perfil>(uuid)?? throw new NotFoundException();
        perfil.MapForUpdate(command);
        await _repository.UpdateAsync(perfil);
        return new (perfil);
    }
}