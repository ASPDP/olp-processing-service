using Microsoft.EntityFrameworkCore;
using Olp.ProcessingService.Core.Domain.Entities;
using Olp.ProcessingService.Core.Domain.Exceptions;
using Olp.ProcessingService.Infrastructure.EntityFramework;
using Olp.ProcessingService.Repositories.Abstractions;

namespace Olp.ProcessingService.Repositories.Implementation;

public class RepositoryBase<TEntity> (
    ProcessingDbContext context
) : IRepositoryBase<Guid, TEntity>
    where TEntity : EntityBase<Guid>
{

    protected ProcessingDbContext Context { get; } = context;
    protected DbSet<TEntity> EntitySet => Context.Set<TEntity>();


    #region IRepositoryBase implementation

    public virtual async Task<TEntity?> GetAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await GetAll(asNoTracking)
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetAsync(IList<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await GetAll(asNoTracking)
            .Where(entity => ids.Contains(entity.Id))
            .ToListAsync(cancellationToken);
    }

    public virtual IQueryable<TEntity> GetAll(bool asNoTracking = false)
    {
        return asNoTracking ? EntitySet.AsNoTracking() : EntitySet;
    }

    public virtual async Task<IList<TEntity>> GetAllAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await GetAll(asNoTracking).ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        var entityEntry = await EntitySet.AddAsync(entity);
        return entityEntry.Entity;
    }

    public virtual void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public virtual async void Update(Guid id, Action<TEntity> setupEntity)
    {
        var entity = await GetAsync(id);
        if (entity == null)
        {
            var exception = new EntityNotFoundException($"Can't update entity. Requested entity wasn't found.");
            exception.Data[EntityNotFoundException.DataEntityIdKey] = id;
            throw exception;
        }

        setupEntity.Invoke(entity);
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetAsync(id);
        if (entity == null)
        {
            return false;
        }
        EntitySet.Remove(entity);
        return true;
    }

    public virtual bool Delete(TEntity entity)
    {
        if (entity == null)
        {
            return false;
        }
        Context.Entry(entity).State = EntityState.Deleted;
        return true;
    }

    public virtual bool DeleteRange(ICollection<TEntity> entities)
    {
        if (entities == null || !entities.Any())
        {
            return false;
        }
        EntitySet.RemoveRange(entities);
        return true;
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }

    #endregion
}
