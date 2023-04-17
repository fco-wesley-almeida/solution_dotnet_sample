using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;

namespace CorteAutomatico.Core.ApplicationModels;

public interface IEntityFactory<TEntity,TRequest> where TEntity: class, IEntity
{
    TEntity CreateForRegister(ICommand<TRequest> command);
    TEntity CreateForUpdate(TEntity entity, Command<TRequest> command);
}