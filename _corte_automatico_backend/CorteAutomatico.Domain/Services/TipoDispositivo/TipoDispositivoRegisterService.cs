using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using CorteAutomatico.Core.Modules.TipoDispositivo.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.TipoDispositivo;

public class TipoDispositivoRegisterService: ITipoDispositivoRegisterService
{
    private readonly IRepository _repository;
    private readonly ITipoDispositivoDb _tipoDispositivoDb;
    private readonly IEntityFactory<Core.Entities.TipoDispositivo, TipoDispositivoRequestDto> _factory;

    public TipoDispositivoRegisterService(
        IRepository repository,
        ITipoDispositivoDb tipoDispositivoDb, 
        IEntityFactory<Core.Entities.TipoDispositivo, TipoDispositivoRequestDto> factory
    )
    {
        _repository = repository;
        _tipoDispositivoDb = tipoDispositivoDb;
        _factory = factory;
    }

    public async Task<TipoDispositivoDto> RegisterAsync(Command<TipoDispositivoRequestDto> command)
    {
        var tipoDispositivo = _factory.CreateForRegister(command);
        tipoDispositivo.Nome = command.Data.Nome;
        tipoDispositivo.Ativo = true;
        await _repository.InsertAsync(tipoDispositivo);
        return (await _tipoDispositivoDb.FindByUuidAsync(tipoDispositivo.Uuid))!;
    }
}