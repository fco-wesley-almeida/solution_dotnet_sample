using CorteAutomatico.Core.Entities;

namespace CorteAutomatico.Core.Repositories;

public interface IRepository
{
    Task<T> InsertAsync<T>(T entity) where T: class,IEntity;
    Task<T> UpdateAsync<T>(T entity) where T: class,IEntity;
    Task<T?> FindByIdAsync<T>(int id) where T: class,IEntity;
    Task<T?> FindByUuidAsync<T>(Guid uuid, bool includeInactive = false) where T: class,IEntity;
    Task<List<T>> FindAllAsync<T>() where T: class,IEntity;
    Task<T?> DeleteAsync<T>(int id) where T: class,IEntity;
    Task<T?> DeleteAsync<T>(T entity) where T: class,IEntity;
}