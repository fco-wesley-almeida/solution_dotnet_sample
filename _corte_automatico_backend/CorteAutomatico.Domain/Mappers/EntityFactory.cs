using System.Text.Json;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;

namespace CorteAutomatico.Domain.Mappers;

public class EntityFactory<TEntity, TRequest>: IEntityFactory<TEntity, TRequest> where TEntity : class, IEntity, new()
{
    private readonly ITimeProvider _timeProvider;

    public EntityFactory(ITimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public TEntity CreateForRegister(ICommand<TRequest> command)
    {
        return new TEntity
        {
            Id = 0,
            Uuid = Guid.NewGuid(),
            CriadoPor = command.JwtContext.Login,
            CriadoEm = _timeProvider.Now(),
            ModificadoPor = command.JwtContext.Login,
            ModificadoEm = _timeProvider.Now(),
            Ativo = true
        };
    }

    public TEntity CreateForUpdate(TEntity entity, Command<TRequest> command)
    {
        var entityUpdated = JsonSerializer.Deserialize<TEntity>(JsonSerializer.Serialize(entity))!;
        entityUpdated.ModificadoPor = command.JwtContext.Login;
        entityUpdated.ModificadoEm = _timeProvider.Now();
        return entityUpdated;
    }
}