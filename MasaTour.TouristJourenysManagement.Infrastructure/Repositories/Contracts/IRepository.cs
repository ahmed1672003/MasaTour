namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Contracts;
public interface IRepository<TEntity> where TEntity : class
{
    #region Commands
    Task CreateAsync(TEntity entity, CancellationToken cancellation = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task<int> ExecuteDeleteAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default);

    #endregion

    #region Queries
    Task<IQueryable<TEntity>> RetrieveAllAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default);
    Task<TEntity> RetrieveAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
    Task<int> CountAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default);
    Task<bool> AllAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default);
    #endregion
}
