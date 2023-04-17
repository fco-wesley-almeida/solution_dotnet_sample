using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;
using CorteAutomatico.Core.Modules.DispositivoMarca.Queries;
using CorteAutomatico.Core.Modules.DispositivoMarca.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.DispositivoMarca;

public class DispositivoMarcaRegisterService : IDispositivoMarcaRegisterService
{
    private readonly IDispositivoMarcaDb _dispositivoMarcaDb;
    private readonly IRepository _repository;
    private Command<DispositivoMarcaRequestDto> _command = null!;

    public DispositivoMarcaRegisterService(
        IRepository repository,
        IDispositivoMarcaDb dispositivoMarcaDb
    )
    {
        _repository = repository;
        _dispositivoMarcaDb = dispositivoMarcaDb;
    }

    public async Task<DispositivoMarcaDto> RegisterAsync(Command<DispositivoMarcaRequestDto> command)
    {
        _command = command;
        var tipoDispositivo = await TipoDispositivo();
        var dispositivoMarca = new Core.Entities.DispositivoMarca().MapForRegister(_command);
        dispositivoMarca.TipoDispositivoId = tipoDispositivo.Id;
        await _repository.InsertAsync(dispositivoMarca);
        return (await _dispositivoMarcaDb.FindByUuid(dispositivoMarca.Uuid))!;
    }

    private async Task<Core.Entities.TipoDispositivo> TipoDispositivo()
    {
        return await _repository.FindByUuidAsync<Core.Entities.TipoDispositivo>(_command.Data.TipoDispositivoUuid) ??
               throw new BadRequestException("Tipo de dispositivo não encontrado");
    }
}