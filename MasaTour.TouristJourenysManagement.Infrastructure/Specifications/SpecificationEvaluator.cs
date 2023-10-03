namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications;
public class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> queryable, ISpecification<TEntity> specification) where TEntity : class
    {
        if (specification is null)
            return queryable;

        IQueryable<TEntity> query = queryable;

        if (specification.IsTrackingOf)
            query = query.AsNoTracking();

        if (specification.IsTrackingWithIdentityResolutionOf)
            query = query.AsNoTrackingWithIdentityResolution();

        if (specification.IsQueryFilterIgnored)
            query = query.IgnoreQueryFilters();

        if (specification.Criteria is not null)
            query = query.Where(specification.Criteria);

        if (specification.Includes.Count() > 0)
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

        if (specification.IncludesString.Count() > 0)
            query = specification.IncludesString.Aggregate(query, (current, includeString) => current.Include(includeString));

        if (specification.OrderBy is not null)
            query = query.OrderBy(specification.OrderBy);

        if (specification.OrderByDescending is not null)
            query = query.OrderByDescending(specification.OrderByDescending);


        if (specification.IsPagingEnabled)
        {
            var pageNumber = specification.PaginationRequirments.pageNumber;
            var pageSize = specification.PaginationRequirments.pageSize;
            query = query.Skip((specification.PaginationRequirments.pageNumber - 1) * pageSize).Take(pageSize);
        }
        return query;
    }
}
