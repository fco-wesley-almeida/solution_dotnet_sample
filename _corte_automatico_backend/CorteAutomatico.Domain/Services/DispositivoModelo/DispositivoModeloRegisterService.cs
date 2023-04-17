using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;
using CorteAutomatico.Core.Modules.DispositivoModelo.Queries;
using CorteAutomatico.Core.Modules.DispositivoModelo.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.DispositivoModelo;

public class DispositivoModeloRegisterService : IDispositivoModeloRegisterService
{
    private readonly IDispositivoModeloDb _dispositivoModeloDb;
    private readonly IRepository _repository;
    private Command<DispositivoModeloRequestDto> _command = null!;

    public DispositivoModeloRegisterService(
        IRepository repository,
        IDispositivoModeloDb dispositivoModeloDb
    )
    {
        _repository = repository;
        _dispositivoModeloDb = dispositivoModeloDb;
    }

    public async Task<DispositivoModeloDto> RegisterAsync(Command<DispositivoModeloRequestDto> command)
    {
        _command = command;
        var dispositivoMarca = await DispositivoMarca();
        var dispositivoModelo = new Core.Entities.DispositivoModelo().MapForRegister(_command);
        dispositivoModelo.DispositivoMarcaId = dispositivoMarca.Id;
        await _repository.InsertAsync(dispositivoModelo);
        return (await _dispositivoModeloDb.FindByUuid(dispositivoModelo.Uuid))!;
    }

    private async Task<Core.Entities.DispositivoMarca> DispositivoMarca()
    {
        return await _repository.FindByUuidAsync<Core.Entities.DispositivoMarca>(_command.Data.DispositivoMarcaUuid) ??
               throw new BadRequestException("Dispositivo marca não encontrado");
    }
}