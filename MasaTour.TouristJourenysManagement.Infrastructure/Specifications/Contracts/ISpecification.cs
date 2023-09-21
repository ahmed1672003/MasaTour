namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Contracts;
public interface ISpecification<TEntity> : ITransientLifetime where TEntity : class
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    List<Expression<Func<TEntity, object>>> Includes { get; }
    Expression<Func<TEntity, object>> OrderBy { get; }
    Expression<Func<TEntity, object>> OrderByDescending { get; }
    Expression<Func<TEntity, object>> GroupBy { get; }
    (Func<TEntity, object> PropertyExpression, Expression<Func<TEntity, object>> ValueExpression) ExecuteUpdateRequirments { get; }
    List<string> IncludesString { get; }
    (int pageNumber, int pageSize) PaginationRequirments { get; }

    bool IsPagingEnabled { get; }
    bool IsTrackingOf { get; }
    bool IsTrackingWithIdentityResolutionOf { get; }
    bool IsQueryFilterIgnored { get; }
}
