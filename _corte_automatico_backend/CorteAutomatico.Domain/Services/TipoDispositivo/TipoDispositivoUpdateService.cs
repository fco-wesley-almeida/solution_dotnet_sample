using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using CorteAutomatico.Core.Modules.TipoDispositivo.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.TipoDispositivo;

public class TipoDispositivoUpdateService: ITipoDispositivoUpdateService
{
    private readonly IRepository _repository;
    private readonly IEntityFactory<Core.Entities.TipoDispositivo, TipoDispositivoRequestDto> _factory;
    private readonly ITipoDispositivoDb _tipoDispositivoDb;

    public TipoDispositivoUpdateService(IRepository repository, IEntityFactory<Core.Entities.TipoDispositivo, TipoDispositivoRequestDto> factory, ITipoDispositivoDb tipoDispositivoDb)
    {
        _repository = repository;
        _factory = factory;
        _tipoDispositivoDb = tipoDispositivoDb;
    }

    public async Task<TipoDispositivoDto> UpdateAsync(Guid uuid, Command<TipoDispositivoRequestDto> command)
    {
        var tipoDispositivoActual = await _repository.FindByUuidAsync<Core.Entities.TipoDispositivo>(uuid, includeInactive: true) 
                           ?? throw new NotFoundException();
        var tipoDispositivo = _factory.CreateForUpdate(tipoDispositivoActual, command);
        Map(command.Data, tipoDispositivo);
        await _repository.UpdateAsync(tipoDispositivo);
        return (await _tipoDispositivoDb.FindByUuidAsync(uuid))!;
    }

    private static void Map(TipoDispositivoRequestDto request, Core.Entities.TipoDispositivo tipoDispositivo)
    {
        tipoDispositivo.Nome = request.Nome;
        tipoDispositivo.Ativo = request.Ativo;
    }
}