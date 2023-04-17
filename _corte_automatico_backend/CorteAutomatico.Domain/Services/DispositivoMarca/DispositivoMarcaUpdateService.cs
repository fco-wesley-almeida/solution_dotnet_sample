using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;
using CorteAutomatico.Core.Modules.DispositivoMarca.Queries;
using CorteAutomatico.Core.Modules.DispositivoMarca.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.DispositivoMarca;

public class DispositivoMarcaUpdateService : IDispositivoMarcaUpdateService
{
    private readonly IDispositivoMarcaDb _dispositivoMarcaDb;
    private readonly IRepository _repository;
    private Command<DispositivoMarcaRequestDto> _command = null!;

    public DispositivoMarcaUpdateService(
        IRepository repository,
        IDispositivoMarcaDb dispositivoMarcaDb
    )
    {
        _repository = repository;
        _dispositivoMarcaDb = dispositivoMarcaDb;
    }

    public async Task<DispositivoMarcaDto> UpdateAsync(Guid uuid, Command<DispositivoMarcaRequestDto> command)
    {
        _command = command;
        var dispositivoMarca = await DispositivoMarca(uuid);
        var tipoDispositivo = await TipoDispositivo();
        dispositivoMarca.MapForUpdate(command);
        dispositivoMarca.TipoDispositivoId = tipoDispositivo.Id;
        await _repository.UpdateAsync(dispositivoMarca);
        return (await _dispositivoMarcaDb.FindByUuid(dispositivoMarca.Uuid))!;
    }

    private async Task<Core.Entities.TipoDispositivo> TipoDispositivo()
    {
        return await _repository.FindByUuidAsync<Core.Entities.TipoDispositivo>(_command.Data.TipoDispositivoUuid) ??
               throw new BadRequestException("Tipo de dispositivo não encontrado");
    }

    private async Task<Core.Entities.DispositivoMarca> DispositivoMarca(Guid uuid)
    {
        return await _repository.FindByUuidAsync<Core.Entities.DispositivoMarca>(uuid) ??
               throw new BadRequestException("Dispositivo marca não encontrado");
    }
}