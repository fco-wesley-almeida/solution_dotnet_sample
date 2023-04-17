using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Perfil.Dtos;
using CorteAutomatico.Core.Modules.Perfil.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.Perfil;

public class PerfilRegisterService : IPerfilRegisterService
{
    private readonly IRepository _repository;

    public PerfilRegisterService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<PerfilDto> RegisterAsync(Command<PerfilRequestDto> command)
    {
        var perfil = new Core.Entities.Perfil().MapForRegister(command);
        await _repository.InsertAsync(perfil);
        return new PerfilDto(perfil);
    }
}