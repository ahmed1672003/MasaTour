using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ITouristTripsManagementDbContext _context;
    protected readonly DbSet<TEntity> _entities;

    public Repository(ITouristTripsManagementDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    #region Commands
    public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellation = default)
    {
        await _entities.AddAsync(entity, cancellation);
    }
    public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _entities.Update(entity);
        return Task.CompletedTask;
    }
    public virtual Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _entities.UpdateRange(entities);
        return Task.CompletedTask;
    }

    public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_entities.Remove(entity));
    }

    public void UndoDeleted<T>(ref T entity) where T : IDeleteableTracker
    {
        entity.IsDeleted = false;
        entity.DeletedAt = null;
    }



    public virtual async Task<int> ExecuteDeleteAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        if (specification?.Criteria is null)
            return await _entities.ExecuteDeleteAsync(cancellationToken);
        else
            return await _entities.Where(specification.Criteria).ExecuteDeleteAsync(cancellationToken);
    }
    #endregion

    #region Queries
    public virtual async Task<bool> AnyAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(_entities, specification).AnyAsync(cancellationToken);
    }

    public virtual async Task<bool> AllAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(_entities, specification).AllAsync(specification.Criteria);
    }

    public virtual async Task<int> CountAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(_entities, specification).CountAsync(cancellationToken);
    }

    public virtual Task<IQueryable<TEntity>> RetrieveAllAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(SpecificationEvaluator.GetQuery(_entities, specification));
    }

    public virtual async Task<TEntity> RetrieveAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(_entities, specification).FirstOrDefaultAsync();
    }
    #endregion
}
