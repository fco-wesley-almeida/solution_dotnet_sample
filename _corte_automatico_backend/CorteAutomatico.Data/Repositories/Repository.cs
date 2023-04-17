using CorteAutomatico.Core.DatabaseContext;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Data.Repositories;

public class Repository: IRepository
{
    private CorteAutomaticoContext _context;

    public Repository(CorteAutomaticoContext context)
    {
        _context = context;
    }

    public async Task<T> InsertAsync<T>(T entity) where T: class,IEntity
    {
        DbSet<T> dbSet = _context.Set<T>();
        await dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync<T>(T entity) where T: class,IEntity
    {
        DbSet<T> dbSet = _context.Set<T>();
        dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> FindByIdAsync<T>(int id) where T: class,IEntity
    {
        DbSet<T> dbSet = _context.Set<T>();
        return await dbSet.AsNoTracking()
            .Where(x => x.Id == id)
            .Where(x => x.Ativo)
            .FirstOrDefaultAsync();
    }

    public Task<T?> FindByUuidAsync<T>(Guid uuid, bool includeInactive = false) where T: class,IEntity
    {
        DbSet<T> dbSet = _context.Set<T>();
        return dbSet.AsNoTracking()
            .Where(x => x.Uuid == uuid)
            .Where(x => includeInactive || x.Ativo)
            .FirstOrDefaultAsync();
    }

    public async Task<List<T>> FindAllAsync<T>() where T: class,IEntity
    {
        DbSet<T> dbSet = _context.Set<T>();
        return await dbSet.AsNoTracking()
            .Where(x => x.Ativo)                  
            .ToListAsync();
    }

    public async Task<T?> DeleteAsync<T>(int id) where T: class,IEntity
    {
        DbSet<T> dbSet = _context.Set<T>();
        var entity = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (entity is null)
        {
            throw new InvalidOperationException();
        }
        return await DeleteAsync(entity);
    }

    public async Task<T?> DeleteAsync<T>(T entity) where T: class,IEntity
    {
        DbSet<T> dbSet = _context.Set<T>();
        dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}