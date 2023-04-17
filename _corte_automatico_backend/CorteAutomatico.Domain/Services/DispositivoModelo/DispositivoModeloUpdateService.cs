using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;
using CorteAutomatico.Core.Modules.DispositivoModelo.Queries;
using CorteAutomatico.Core.Modules.DispositivoModelo.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.DispositivoModelo;

public class DispositivoModeloUpdateService : IDispositivoModeloUpdateService
{
    private readonly IDispositivoModeloDb _dispositivoModeloDb;
    private readonly IRepository _repository;
    private Command<DispositivoModeloRequestDto> _command = null!;

    public DispositivoModeloUpdateService(
        IRepository repository,
        IDispositivoModeloDb dispositivoModeloDb
    )
    {
        _repository = repository;
        _dispositivoModeloDb = dispositivoModeloDb;
    }

    public async Task<DispositivoModeloDto> UpdateAsync(Guid uuid, Command<DispositivoModeloRequestDto> command)
    {
        _command = command;
        var dispositivoModelo = await DispositivoModelo(uuid);
        var dispositivoMarca = await DispositivoMarca();
        dispositivoModelo.MapForUpdate(_command);
        dispositivoModelo.DispositivoMarcaId = dispositivoMarca.Id;
        await _repository.UpdateAsync(dispositivoModelo);
        return (await _dispositivoModeloDb.FindByUuid(dispositivoModelo.Uuid))!;
    }

    private async Task<Core.Entities.DispositivoMarca> DispositivoMarca()
    {
        return await _repository.FindByUuidAsync<Core.Entities.DispositivoMarca>(_command.Data.DispositivoMarcaUuid) ??
               throw new BadRequestException("Dispositivo marca não encontrado");
    }

    private async Task<Core.Entities.DispositivoModelo> DispositivoModelo(Guid uuid)
    {
        return await _repository.FindByUuidAsync<Core.Entities.DispositivoModelo>(uuid) ??
               throw new NotFoundException();
    }
}