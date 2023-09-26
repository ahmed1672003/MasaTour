namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications;
public class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    public Specification(Expression<Func<TEntity, bool>> criteria = null)
    {
        PaginationRequirments = (1, 10);
        Criteria = criteria;
    }
    public List<Expression<Func<TEntity, object>>> Includes { get; private set; } = new List<Expression<Func<TEntity, object>>>();
    public List<string> IncludesString { get; private set; } = new List<string>();
    public Expression<Func<TEntity, bool>> Criteria { get; private set; }
    public Expression<Func<TEntity, object>> OrderBy { get; private set; }
    public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
    public Expression<Func<TEntity, object>> GroupBy { get; private set; }
    public bool IsPagingEnabled { get; private set; }
    public bool IsTrackingOf { get; private set; }
    public bool IsTrackingWithIdentityResolutionOf { get; private set; }
    public bool IsQueryFilterIgnored { get; private set; }
    public (int pageNumber, int pageSize) PaginationRequirments { get; private set; }
    public object ExecuteUpdateValue { get; private set; }

    protected virtual void AddIncludes(Expression<Func<TEntity, object>> include) => Includes.Add(include);
    protected virtual void AddIncludesString(string includesString) => IncludesString.Add(includesString);
    protected virtual void AddOrderBy(Expression<Func<TEntity, object>> orderBy) => OrderBy = orderBy;
    protected virtual void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescending) => OrderByDescending = orderByDescending;
    protected virtual void AddExecuteUpdateValue(object executeUpdateValue) => ExecuteUpdateValue = executeUpdateValue;
    protected virtual void ApplyGroupBy(Expression<Func<TEntity, object>> groupBy) => GroupBy = groupBy;
    protected virtual void StopTracking() => IsTrackingOf = true;
    protected virtual void StopTrackingWithIdentityResolution() => IsTrackingWithIdentityResolutionOf = true;
    protected virtual void IgnorQueryFilter() => IsQueryFilterIgnored = true;
    protected virtual void ApplyPaging((int pageNumber, int pageSize) paginationRequirments)
    {
        PaginationRequirments = paginationRequirments;
        IsPagingEnabled = true;
    }
}
