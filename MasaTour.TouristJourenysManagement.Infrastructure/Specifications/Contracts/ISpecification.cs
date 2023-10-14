namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Contracts;
public interface ISpecification<TEntity> where TEntity : class
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    List<Expression<Func<TEntity, object>>> Includes { get; }
    Expression<Func<TEntity, object>> OrderBy { get; }
    Expression<Func<TEntity, object>> OrderByDescending { get; }
    Expression<Func<TEntity, object>> GroupBy { get; }
    object ExecuteUpdateValue { get; }
    List<string> IncludesString { get; }
    (int pageNumber, int pageSize) PaginationRequirments { get; }

    bool IsPagingEnabled { get; }
    bool IsTrackingOf { get; }
    bool IsTrackingWithIdentityResolutionOf { get; }
    bool IsQueryFilterIgnored { get; }

    public static class SelectEvaluator<TResult>
    {
        public static Expression<Func<TEntity, TResult>> Select { get; private set; }

        public static void AddSelect(Expression<Func<TEntity, TResult>> select)
        {
            Select = select;
        }
    }
}